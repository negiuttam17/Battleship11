using Battleship11;
using Moq;

namespace Battleship11.Test
{
    public class ProgramTest
    {
        [Fact]
        public void Test1()
        {

            //Program.Attack();
           // Assert.True("Hit", )
           
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

            //Battleship11.Program.Attack();
        }

        [Theory]
        [InlineData(3, "C", 1)]
        [InlineData(3, "D", 2)]
        public void PutShipTest(int shiplen, string shipname, int playernum)
        {
            int row=0, col=0;
            Battleship11.Program.PutShip(shiplen, shipname, playernum);
            for (int i=0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                   if(Battleship11.Program.pBoard[i, j] != null)
                    {
                        row = i;
                        col = j;
                    }
                }
            }
            if (playernum == 1)
                Assert.Contains(Battleship11.Program.pBoard[row, col], "C");
            else
                Assert.Contains(Battleship11.Program.pBoard[row, col], "D");


        }
    }
}