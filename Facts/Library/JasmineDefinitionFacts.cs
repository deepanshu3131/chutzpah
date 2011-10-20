﻿namespace Chutzpah.Facts.Library
{
    using System.Collections.Generic;
    using Chutzpah.Facts.Properties;
    using Chutzpah.FrameworkDefinitions;
    using Xunit;
    using Xunit.Extensions;

    public class JasmineDefinitionFacts
    {
        public class FileUsesFramework
        {
            public static IEnumerable<object[]> TestSuites
            {
                get
                {
                    return new object[][]
                    {
                        new object[] { Resources.JSSpecSuite },
                        new object[] { Resources.JsTestDriverSuite },
                        new object[] { Resources.QUnitSuite },
                        new object[] { Resources.YUITestSuite }
                    };
                }
            }

            [Fact]
            public void ReturnsTrue_WithJasmineSuiteAndDefinitiveDetection()
            {
                var definition = new JasmineDefinition();
                Assert.True(definition.FileUsesFramework(Resources.JasmineSuite, false));
            }

            [Fact]
            public void ReturnsTrue_WithJasmineSuiteAndBestGuessDetection()
            {
                var definition = new JasmineDefinition();
                Assert.True(definition.FileUsesFramework(Resources.JasmineSuite, true));
            }

            [Theory]
            [PropertyData("TestSuites")]
            public void ReturnsFalse_WithForeignSuiteAndDefinitiveDetection(string suite)
            {
                var definition = new JasmineDefinition();
                Assert.False(definition.FileUsesFramework(suite, false));
            }

            [Theory]
            [PropertyData("TestSuites")]
            public void ReturnsFalse_WithForeignSuiteAndBestGuessDetection(string suite)
            {
                var definition = new JasmineDefinition();
                Assert.False(definition.FileUsesFramework(suite, true));
            }
        }
    }
}