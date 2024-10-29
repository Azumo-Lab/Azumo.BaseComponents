using Azumo.BaseComponents;
using Azumo.BaseComponents.PipelineModules;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var pipelineBuilder = PipelineBuilder<TestResult>.Create();
            pipelineBuilder.AddProcess(new TestProcess01());
            pipelineBuilder.AddProcess(new TestProcess02());
            var pipeline = pipelineBuilder.BuildPipeline();

            var result = new TestResult();

            pipeline.ExecuteAsync(result);

            Assert.AreEqual("TestProcess01TestProcess02", result.Result);

            SimpleConfigurationFile.Initialize();
            SimpleConfigurationFile.Write("TestResult", result.Result);
            SimpleConfigurationFile.End();
        }
    }

    public class TestProcess01 : IPipelineProcess<TestResult>
    {
        public Task ExecuteAsync(TestResult input, PipelineDelegate<TestResult> Next)
        {
            input.Result += "TestProcess01";
            return Next(input);
        }
    }

    public class TestProcess02 : IPipelineProcess<TestResult>
    {
        public Task ExecuteAsync(TestResult input, PipelineDelegate<TestResult> Next)
        {
            input.Result += "TestProcess02";
            return Next(input);
        }
    }

    public class TestResult : IPipelineResult
    {
        public string Result { get; set; } = string.Empty;
    }
}