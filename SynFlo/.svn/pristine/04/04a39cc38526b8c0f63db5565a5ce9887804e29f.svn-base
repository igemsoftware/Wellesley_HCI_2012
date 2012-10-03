using Microsoft.Xna.Framework;
using System;

namespace EcoliWorld
{
    /// <summary>
    /// Describes the location, orientation, and scale of a sprite.The moving vector to increment
    /// </summary>
    public class SpriteData
    {
        public Vector2 location;
        public float orientation;
        public float scale;

        //private static Random randomX = new Random();
        //private static Random randomY = new Random();

        
        public Vector2 moveFactor; //= new Vector2( randomX.Next(-1000, 1000), randomY.Next(-1000, 1000));
        


        /// <summary>
        /// The location of the sprite.
        /// </summary>
        public Vector2 Location
        {
            get { return location; }
            set { location = value; }
        }

        /// <summary>
        /// Factor that get incremented for movement.
        /// Not called in SpriteBatch.Draw 
        /// </summary>
        public Vector2 MoveFactor
        {
            get { return moveFactor; }
            set { moveFactor = value; }
        }

        /// <summary>
        /// The orientation of the sprite.
        /// </summary>
        public float Orientation
        {
            get { return orientation; }
            set { orientation = value; }
        }

        /// <summary>           
        /// The scale of the sprite.
        /// </summary>
        public float Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="location">initial location</param>
        /// <param name="orientation">initial orientation</param>
        /// <param name="scale">initial scale</param>
        public SpriteData(Vector2 location, float orientation, float scale)
        {
            this.location = location;
            this.orientation = orientation;
            this.scale = scale;
        }
    }
}
