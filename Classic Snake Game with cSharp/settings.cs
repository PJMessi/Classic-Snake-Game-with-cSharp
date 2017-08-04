using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classic_Snake_Game_with_cSharp
{
    public enum Direction { up, down, left, right};
    class settings
    {
        public static int width { get; set; }
        public static int height { get; set; }
        public static int speed { get; set; }
        public static int score { get; set; }
        public static int points { get; set; }
        public static bool gameOver { get; set; }
        public static Direction direction { get; set; }  

        public settings()
        {
            gameOver = false;
            width = 16;
            height = 16;
            speed = 16;
            score = 0;
            points = 100;
            direction = Direction.down;
            
        }
    }
}
