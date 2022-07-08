using Shouldly;
using Xunit;

namespace Dojo.Diamond.Specs.Features.DiamondBuilder;

public class DiamondBuilderShould
{
    [Theory]
    [InlineData('1')]
    [InlineData('!')]
    public void Throw_if_input_not_alpha(char input)
    {
        var action = () => Diamond.Features.DiamondBuilder.Build(input);

        action.ShouldThrow<ArgumentException>();
    }

    [Fact]
    public void Return_single_letter_when_A()
    {
        const char input = 'A';

        var diamond = Diamond.Features.DiamondBuilder.Build(input);

        diamond.Count.ShouldBe(1);
        diamond[0].ShouldBe("A");
    }
    
    [Fact]
    public void Handle_lowercase()
    {
        const char input = 'a';

        var diamond = Diamond.Features.DiamondBuilder.Build(input);

        diamond.Count.ShouldBe(1);
        diamond[0].ShouldBe("A");
    }
    
    [Fact]
    public void Return_three_rows_when_B()
    {
        const char input = 'B';

        var diamond = Diamond.Features.DiamondBuilder.Build(input);

        diamond.Count.ShouldBe(3);
        diamond[0].ShouldBe(" A ");
        diamond[1].ShouldBe("B B");
        diamond[2].ShouldBe(" A ");
    }
    
    [Fact]
    public void Return_five_rows_when_C()
    {
        const char input = 'C';

        var diamond = Diamond.Features.DiamondBuilder.Build(input);

        diamond.Count.ShouldBe(5);
        diamond[0].ShouldBe("  A  ");
        diamond[1].ShouldBe(" B B ");
        diamond[2].ShouldBe("C   C");
        diamond[3].ShouldBe(" B B ");
        diamond[4].ShouldBe("  A  ");
    }
}
