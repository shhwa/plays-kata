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
            var hamlet = new Play("Hamlet", "tragedy");
            var asyoulikeit = new Play("As You Like It", "comedy");
            var othello = new Play("Othello", "tragedy");
            
            plays.Add("hamlet", hamlet);
            plays.Add("as-like", asyoulikeit);
            plays.Add("othello", othello);

            Invoice invoice = new Invoice("BigCo", new List<Performance>{new Performance(hamlet, 55),
                new Performance(asyoulikeit, 35),
                new Performance(othello, 40)});
            
            StatementPrinter statementPrinter = new StatementPrinter();
            var result = statementPrinter.Print(invoice, plays);

            string expectedResult = "Statement for BigCo"
                                    + "\n  Hamlet: $650.00 (55 seats)"
                                    + "\n  As You Like It: $580.00 (35 seats)"
                                    + "\n  Othello: $500.00 (40 seats)"
                                    + "\nAmount owed is $1,730.00"
                                    + "\nYou earned 47 credits"
                                    + "\n";

            Assert.That(result, Is.EqualTo(expectedResult));
        }
        
        [Test]
        public void test_statement_with_new_play_types()
        {
            var plays = new Dictionary<string, Play>();
            var henryv = new Play("Henry V", "history");
            var asyoulikeit = new Play("As You Like It", "pastoral");
            
            plays.Add("henry-v", henryv);
            plays.Add("as-like", asyoulikeit);

            Invoice invoice = new Invoice("BigCoII", new List<Performance>{new Performance(henryv, 53),
                new Performance(asyoulikeit, 55)});
            
            StatementPrinter statementPrinter = new StatementPrinter();

            Assert.Throws<Exception>(() => statementPrinter.Print(invoice, plays));
        }
    }
}
