using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TheatricalPlayersRefactoringKata.Tests
{
    public class StatementPrinterTests
    {
        [Test]
        public void test_statement_example()
        {
            var plays = new Dictionary<string, Play>();
            plays.Add("hamlet", new Play("Hamlet", "tragedy"));
            plays.Add("as-like", new Play("As You Like It", "comedy"));
            plays.Add("othello", new Play("Othello", "tragedy"));

            Invoice invoice = new Invoice("BigCo", new List<Performance>{new Performance("hamlet", 55),
                new Performance("as-like", 35),
                new Performance("othello", 40)});
            
            StatementPrinter statementPrinter = new StatementPrinter();
            var result = statementPrinter.Print(invoice, plays);

            string expectedResult = "Statement for BigCo"
                                    + "Hamlet: $650.00 (55 seats)"
                                    + "As You Like It: $580.00 (35 seats)"
                                    + "Othello: $500.00 (40 seats)"
                                    + "Amount owed is $1,730.00"
                                    + "You earned 47 credits";

            Assert.That(result, Is.EqualTo(result));
        }
        
        [Test]
        public void test_statement_with_new_play_types()
        {
            var plays = new Dictionary<string, Play>();
            plays.Add("henry-v", new Play("Henry V", "history"));
            plays.Add("as-like", new Play("As You Like It", "pastoral"));

            Invoice invoice = new Invoice("BigCoII", new List<Performance>{new Performance("henry-v", 53),
                new Performance("as-like", 55)});
            
            StatementPrinter statementPrinter = new StatementPrinter();

            Assert.Throws<Exception>(() => statementPrinter.Print(invoice, plays));
        }
    }
}
