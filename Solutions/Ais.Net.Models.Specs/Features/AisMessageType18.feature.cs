﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by Reqnroll (https://www.reqnroll.net/).
//      Reqnroll Version:2.0.0.0
//      Reqnroll Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Ais.Net.Models.Specs.Features
{
    using Reqnroll;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("AisMessageType18")]
    public partial class AisMessageType18Feature
    {
        
        private global::Reqnroll.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "AisMessageType18.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual async System.Threading.Tasks.Task FeatureSetupAsync()
        {
            testRunner = global::Reqnroll.TestRunnerManager.GetTestRunnerForAssembly();
            global::Reqnroll.FeatureInfo featureInfo = new global::Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "AisMessageType18", null, global::Reqnroll.ProgrammingLanguage.CSharp, featureTags);
            await testRunner.OnFeatureStartAsync(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual async System.Threading.Tasks.Task FeatureTearDownAsync()
        {
            await testRunner.OnFeatureEndAsync();
            global::Reqnroll.TestRunnerManager.ReleaseTestRunner(testRunner);
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public async System.Threading.Tasks.Task TestInitializeAsync()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public async System.Threading.Tasks.Task TestTearDownAsync()
        {
            await testRunner.OnScenarioEndAsync();
        }
        
        public void ScenarioInitialize(global::Reqnroll.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public async System.Threading.Tasks.Task ScenarioStartAsync()
        {
            await testRunner.OnScenarioStartAsync();
        }
        
        public async System.Threading.Tasks.Task ScenarioCleanupAsync()
        {
            await testRunner.CollectScenarioErrorsAsync();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create AisMessageType18 record")]
        public async System.Threading.Tasks.Task CreateAisMessageType18Record()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Create AisMessageType18 record", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 3
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
                global::Reqnroll.Table table1 = new global::Reqnroll.Table(new string[] {
                            "CanAcceptMessage22ChannelAssignment",
                            "CanSwitchBands",
                            "CourseOverGroundDegrees",
                            "CsUnit",
                            "HasDisplay",
                            "IsAssigned",
                            "IsDscAttached",
                            "Mmsi",
                            "Position_Latitude",
                            "Position_Longitude",
                            "PositionAccuracy",
                            "RadioStatusType",
                            "RaimFlag",
                            "RegionalReserved139",
                            "RegionalReserved38",
                            "RepeatIndicator",
                            "SpeedOverGround",
                            "TimeStampSecond",
                            "TrueHeadingDegrees"});
                table1.AddRow(new string[] {
                            "true",
                            "true",
                            "123.45",
                            "Cstdma",
                            "true",
                            "true",
                            "true",
                            "12345",
                            "1",
                            "2",
                            "true",
                            "Itdma",
                            "true",
                            "1",
                            "2",
                            "3",
                            "12.34",
                            "56",
                            "78"});
#line 4
    await testRunner.GivenAsync("a new AisMessageType18 record with the following properties:", ((string)(null)), table1, "Given ");
#line hidden
#line 7
    await testRunner.WhenAsync("the AisMessageType is created", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 8
    await testRunner.ThenAsync("the properties should be set correctly", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
    }
}
#pragma warning restore
#endregion
