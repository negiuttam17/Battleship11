using Battleship11;
using Moq;

namespace Battleship11.Test
{
    public class Program
    {
        [Fact]
        public void Test1()
        {

            //Program.Attack();
           
        }

       
        [Theory]
        [InlineData("P1")]
        [InlineData("P2")]
        public void drawBoardTest(string selection)
        {
            Battleship11.Program.drawBoard(selection);
            if(selection == "P1")
                Assert.Equal(Battleship11.Program.p1Board.Length, 10*10);
            else
                Assert.Equal(Battleship11.Program.p2Board.Length, 10*10);
        }

        [Fact]
        public void PutShipOnBoardTest()
        {

            Battleship11.Program.PutShipOnBoard1();
            
        }
    }
}