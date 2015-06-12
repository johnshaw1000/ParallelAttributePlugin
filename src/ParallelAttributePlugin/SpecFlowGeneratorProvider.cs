namespace ParallelAttributePlugin
{
    using System.CodeDom;
    using TechTalk.SpecFlow.Generator;
    using TechTalk.SpecFlow.Generator.UnitTestProvider;
    using TechTalk.SpecFlow.Utils;

    // ReSharper disable once ClassNeverInstantiated.Global
    public class SpecFlowGeneratorProvider : NUnitTestGeneratorProvider
    {
        public SpecFlowGeneratorProvider(CodeDomHelper codeDomHelper) : base(codeDomHelper)
        { }

        public override void FinalizeTestClass(TestClassGenerationContext generationContext)
        {
            var parallelAttribute = new CodeAttributeDeclaration("NUnit.Framework.Parallelizable", new CodeAttributeArgument(new CodeTypeReferenceExpression("NUnit.Framework.ParallelScope.Fixtures")));

            generationContext.TestClass.CustomAttributes.Add(parallelAttribute);
            
            base.FinalizeTestClass(generationContext);
        }
    }
}
