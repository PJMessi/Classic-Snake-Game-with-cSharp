using System.Windows.Forms;
using System.Collections;

namespace Classic_Snake_Game_with_cSharp
{
     class inputs
    {
        private static Hashtable keyTable = new Hashtable();//load list of availiable keyboard buttons

        public static bool keyPressed(Keys key)//check to see if a particular button is pressed
        {

            if (keyTable[key] == null)
            {
                return false;
            }
            return (bool) keyTable[key];
        }

        public static void changeState(Keys key, bool state)
        {

            keyTable[key] = state;
        }

    }
}
    


