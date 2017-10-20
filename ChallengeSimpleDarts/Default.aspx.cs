using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DartBoard;


namespace ChallengeSimpleDarts
{
    public partial class Default : System.Web.UI.Page
    {
        Random myLuckyDay = new Random();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Darts DartGame = new Darts(myLuckyDay);
                Game myGame = new Game(DartGame);
                myGame.PlayDarts();  //Actually call the game.
                fillResultLabel(myGame);
                
            }
        }

        private void fillResultLabel(Game thisGame)
        {
            //in case of tie:
            if(thisGame.score1 == thisGame.score2)
            {
                lblDartsResults.Text = String.Format(" We have a TIE between {0} and {1}!!!", thisGame.player1, thisGame.player2);
            }
            else if (thisGame.score1 > thisGame.score2)
            {
                lblDartsResults.Text = String.Format(" The WINNER is  {0} with a score of  {1}!", thisGame.player1, thisGame.score1);
            }
            else
            {
                lblDartsResults.Text = String.Format(" The WINNER is  {0} with a score of  {1}!", thisGame.player2, thisGame.score2);
            }
            lblDartsResults.Text += String.Format(" <br/> The final score for  {0} is:  {1}!", thisGame.player1, thisGame.score1);
            lblDartsResults.Text += String.Format(" <br/> The final score for  {0} is:  {1}!", thisGame.player2, thisGame.score2);
        }







        public class Game
        {
            Darts Darts;
            public string player1 = "Freddy";
            public string player2 = "Yun-Mi";

            public int score1 { get; set; } = 0;
            public int score2 { get; set; } = 0;

            public Game(Darts myDarts)
            {
                this.Darts = myDarts;
            }

            public void PlayDarts()
            {
                //enter loop that lets each player play (3 throws per play)
                while(score1<300 && score2 < 300)
                {
                    for(int i = 1; i < 3; i++)
                    {
                        Darts.Throw();
                        //send properties to scoring method
                        score1 += scorrer();
                    }
                    for (int i = 1; i < 3; i++)
                    {
                        Darts.Throw();
                        //send properties to scoring method
                        score2+= scorrer();
                    }
                    
                }

                

            }

            private int scorrer()
            {
                if(Darts.Zone == 0)
                {
                    if (Darts.OuterRing == false) return 50;
                    else return 25;
                }
                else
                {
                    if (Darts.InnerRing == false && Darts.OuterRing == false) return Darts.Zone;
                    if (Darts.InnerRing == true) return Darts.Zone * 3;
                    if (Darts.OuterRing == true) return Darts.Zone * 2;
                }

                return 0;  //This line should never be reached.
            }

            private void outputLabel()
            {
                if(score1==score2)
                {
               



                }

            }
        }
    }
}