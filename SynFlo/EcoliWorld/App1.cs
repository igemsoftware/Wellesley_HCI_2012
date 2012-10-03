using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Microsoft.Surface;
using Microsoft.Surface.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EcoliWorld
{
    /// <summary>
    /// This sample demonstrates a very simple drawing technique.
    /// </summary>
    public class App1 : Microsoft.Xna.Framework.Game
    {
        #region Variables 
        private readonly GraphicsDeviceManager graphics;
        private TouchTarget touchTarget;
        private bool applicationLoadCompleteSignalled;
        private const int millisecondsToDisappear = 60000;
        private SpriteBatch foregroundBatch;
        private SpriteBatch tailBatch;
        private Texture2D touchSprite; //gonna have to change the name or make a second texture, for color&Ecoli
        private Texture2D tailSprite;
        private Vector2 spriteOrigin;
        private Vector2 tailOrigin;
        private Vector2 orginPlaceHolder; //not used
        private Vector2 spriteSpeed = new Vector2(1, 500); //move version to sprite data

               
        private LinkedList<SpriteData> sprites = new LinkedList<SpriteData>();
        private LinkedList<SpriteData> spriteTail = new LinkedList<SpriteData>();

        private List<LinkedList<SpriteData>> ecoliList = new List<LinkedList<SpriteData>>();

        #endregion 
        #region FingerFountain Sprites

        /// <summary>
        /// Moves ecoli the specified amount.
        /// Increment the orgin?
        /// </summary>
        /// <param name="gameTime">time to divide by</param>
        private void MoveEcoli(GameTime gameTime )
        {// spritePosition = spriteOrigin
            //myTexture = touchSprite
            int changeMoveFactor = 0;
            changeMoveFactor++;
            int changeAddSubtract = 0;
            changeAddSubtract++;
            spriteSpeed = new Vector2(1,1); 
            foreach (LinkedList<SpriteData> ecoli in ecoliList)
            {
                //foreach (SpriteData sprite in ecoli)
                //{
                Random randomX = new Random();
                Random randomY = new Random();
                Random randomZ = new Random();

                LinkedListNode<SpriteData> currentNode = ecoli.Last;
                //currentNode.Value.moveFactor = new Vector2(randomX.Next(0, 30), randomY.Next(0, 30));

                currentNode.Value.moveFactor.X = randomX.Next(0, 80) / randomX.Next(1, 5);
                currentNode.Value.moveFactor.Y = randomY.Next(0, 80); // randomX.Next(-5, );
                Console.WriteLine("currentNode.Value.moveFactor.X" + currentNode.Value.moveFactor.X);
                Console.WriteLine("currentNode.Value.moveFactor.Y" + currentNode.Value.moveFactor.Y);
                //currentNode.Value.moveFactor.X = 79;
                //currentNode.Value.moveFactor 
                // go through the whole list and decrement the scale value
                //LinkedListNode<SpriteData> currentNode = spriteTail.First;
                //while (currentNode != null)
                //{
                //currentNode.Value.Scale -= shrinkBy;
                //orginPlaceHolder = spriteOrigin;
                //currentNode.Value.MoveFactor = spriteOrigin + spriteSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

                //currentNode.Value.location += spriteSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (changeMoveFactor == 10)
                {
                    currentNode.Value.moveFactor = new Vector2(randomX.Next(10, 130), randomY.Next(80, 190));
                    changeMoveFactor = 0;

                }

                if (randomZ.Next(0,100) % 2 == changeAddSubtract)
                {
                    currentNode.Value.location += currentNode.Value.moveFactor * spriteSpeed; //* (float)gameTime.ElapsedGameTime.TotalSeconds;
                    changeAddSubtract = 0;
                }
                else
                {
                    currentNode.Value.location -= currentNode.Value.moveFactor * spriteSpeed; //* (float)gameTime.ElapsedGameTime.TotalSeconds;
                    changeAddSubtract = 0;
                }
                            
                //spriteOrigin += spriteSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                //Something weird is happeneing where the ecoli shows not exactly where my mouse is...
                //orginPlaceHolder = spriteSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                #region Window size variables
                int MaxX = Program.WindowWidth - touchSprite.Width;
                //int MaxX = 900;
                Console.WriteLine("Window size" + MaxX);
                //graphics.GraphicsDevice.Viewport.Width - touchSprite.Width;
                int MinX = 0;
                int MaxY = Program.WindowHeight - touchSprite.Height;
                //int MaxY = 100;
                Console.WriteLine("Window height" + MaxY);
                //graphics.GraphicsDevice.Viewport.Height - touchSprite.Height;
                int MinY = 0;
                #endregion
                #region Check for bounce.
                if (currentNode.Value.Location.X > MaxX)
                {
                    spriteSpeed.X *= -1;
                    currentNode.Value.location.X = MaxX;
                }
                        
                else if (currentNode.Value.Location.X < MinX)
                {
                    spriteSpeed.X *= -1;
                    currentNode.Value.location.X = MinX;
                }

                if (currentNode.Value.Location.Y > MaxY)
                {
                    spriteSpeed.Y *= -1;
                    currentNode.Value.location.Y = MaxY;
                }

                else if (currentNode.Value.Location.Y < MinY)
                {
                    spriteSpeed.Y *= -1;
                    currentNode.Value.location.Y = MinY;
                }
                #endregion
                //This is need to assign the new movement, but i'm not sure where. 
                //Help me God!
                //Below negates effect. No it doesn't. 
                //spriteOrigin = orginPlaceHolder; 
                //spriteOrigin = currentNode.Value.MoveFactor; 
                //sprites also need to bounce and interact with each other. 
                //currentNode = currentNode.Next;
                //}
                    
                //}
            }
        }

        /// <summary>
        /// Reduces the scale of each sprite in the sprites list by
        /// the specified amount.
        /// </summary>
        /// <param name="shrinkBy">amount to shrink by</param>
        private void ShrinkSprites(float shrinkBy)
        {
            foreach (LinkedList<SpriteData> ecoli in ecoliList)
            {
                // go through the whole list and decrement the scale value
                //LinkedListNode<SpriteData> currentNode = sprites.First;
                LinkedListNode<SpriteData> currentNode = ecoli.First;
                while (currentNode != null)
                {
                    currentNode.Value.Scale -= shrinkBy;
                    currentNode = currentNode.Next;
                }
            }
        }

        /// <summary>
        /// Removes any sprites with a scale of zero or lower.
        /// </summary>
        private void RemoveInvisibleSprites()
        {
            // Since the sprites are always added to the end,  --we eventually want to add to the second from end? 
            // removals will always come from the beginning.
            while (sprites.First != null && sprites.First.Value.Scale <= 0.0f)
            {
                sprites.RemoveFirst();
            }
        }

        /// <summary>Not used anymore
        /// Creates a new sprite at each touch location. 
        /// </summary>
        private int InsertSpritesAtTouchPositions(ReadOnlyTouchPointCollection touches)
        {
            //eventually each sprite has to be different and have it's own list? 
            int count = 0;
            foreach (TouchPoint touch in touches)
            {
                // Create a sprite for each touch that has been recognized as a finger, 
                // or for any touch if finger recognition is not supported.
                        //needs to create a new list of spirtes with a n ecoli heading it and a tail behind it, with an id?
                if (touch.IsFingerRecognized || InteractiveSurface.PrimarySurfaceDevice.IsFingerRecognitionSupported == false)
                {
                    
                    //spriteOrigin = new Vector2(touch.X, touch.Y);
                    SpriteData sprite = new SpriteData(new Vector2(touch.X, touch.Y), touch.Orientation, 1.0f); 
                    sprites.AddLast(sprite); // always add to the end
                    count++;
                }
            }
            return count;
        }


        /// <summary> *****************************
        /// Creates a new sprite List at each touch location.
        /// </summary>
        /// <param name="touches">Where the touch is</param>
        private int InsertEcoliAtTouchPosition(ReadOnlyTouchPointCollection touches)
        {
            //eventually each sprite has to be different and have it's own list? 
            int count = 0;
            foreach (TouchPoint touch in touches)
            {
                // Creates a ecoli list for each touch that has been recognized as a finger, 
                // or for any touch if finger recognition is not supported.
                        //needs to create a new list of spirtes with a n ecoli heading it and a tail behind it, with an id?
                if (touch.IsFingerRecognized || InteractiveSurface.PrimarySurfaceDevice.IsFingerRecognitionSupported == false)
                {
                    //make a new linkedlist for the ecoli and a trail
                    LinkedList<SpriteData> ecoli = new LinkedList<SpriteData>();

                        //Add a new functin? Find out what color Ecoli and display the right color sprite and color tail 
                        //?? ARE WE SITLL DOING THIS?? If it's the cleaner or the toxic one then Black or white tail? 
                   
                    //spriteOrigin = new Vector2(touch.X, touch.Y);
                    SpriteData sprite = new SpriteData(new Vector2(touch.X, touch.Y), touch.Orientation, 1.0f); //would add the color 
                    ecoli.AddLast(sprite); // always add to the end //just add? nope.

                    //Finally add LinkedList onto List of LinkedList so that it can be included when drawn
                    ecoliList.Add(ecoli);

                    //Is it helpful to be counting? 
                    count++;
                }
            }
            return count;
        }

        /// <summary> 
        /// Used to create tail and add tail segments 
        /// </summary>
        /// <param name=" "> </param>
        /// <returns></returns>
        private int InsertTrailAfterEcoli ()
        {
            int count = 0;
            //In each of the ecoli in ecoliList
            foreach (LinkedList<SpriteData> ecoli in ecoliList)
            {
                SpriteData trailColor = new SpriteData(ecoli.Last.Value.Location, ecoli.Last.Value.Orientation, 1.0f);
                ecoli.AddBefore(ecoli.Last, trailColor );
            }
            return count;
        }


        #endregion

        #region WindowForms Handeling: Update(); Load();
        /// <summary>
        /// Default constructor.
        /// </summary>
        public App1()
        {
            graphics = new GraphicsDeviceManager(this);
        }

        /// <summary>
        /// Allows the app to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            IsMouseVisible = true; // easier for debugging not to "lose" mouse
            IsFixedTimeStep = false; // we will update based on time
            SetWindowOnSurface();
            InitializeSurfaceInput();

            // Subscribe to surface window availability events
            ApplicationServices.WindowInteractive += OnWindowInteractive;
            ApplicationServices.WindowNoninteractive += OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable += OnWindowUnavailable;

            base.Initialize();
        }

        /// <summary>
        /// Moves and sizes the window to cover the input surface.
        /// </summary>
        private void SetWindowOnSurface()
        {
            System.Diagnostics.Debug.Assert(Window != null && Window.Handle != IntPtr.Zero,
                "Window initialization must be complete before SetWindowOnSurface is called");
            if (Window == null || Window.Handle == IntPtr.Zero)
                return;

            // Get the window sized right.
            Program.InitializeWindow(Window);
            // Set the graphics device buffers.
            graphics.PreferredBackBufferWidth = Program.WindowSize.Width;
            graphics.PreferredBackBufferHeight = Program.WindowSize.Height;
            graphics.ApplyChanges();
            // Make sure the window is in the right location.
            Program.PositionWindow();
        }

        /// <summary>
        /// Initializes the surface input system. This should be called after any window
        /// initialization is done, and should only be called once.
        /// </summary>
        private void InitializeSurfaceInput()
        {
            System.Diagnostics.Debug.Assert(Window != null && Window.Handle != IntPtr.Zero,
                "Window initialization must be complete before InitializeSurfaceInput is called");
            if (Window == null || Window.Handle == IntPtr.Zero)
                return;
            System.Diagnostics.Debug.Assert(touchTarget == null,
                "Surface input already initialized");
            if (touchTarget != null)
                return;

            // Create a target for surface input.
            touchTarget = new TouchTarget(Window.Handle, EventThreadChoice.OnBackgroundThread);
            touchTarget.EnableInput();
        }

        /// <summary>
        /// Load your graphics content.
        /// </summary>.
        protected override void LoadContent()
        {
            string filename = System.Windows.Forms.Application.ExecutablePath;
            string path = System.IO.Path.GetDirectoryName(filename) + "\\EcoliWorldContent\\";

            foregroundBatch = new SpriteBatch(graphics.GraphicsDevice);
            using (Stream textureFileStream = File.OpenRead(Path.Combine(path, "ecoli.jpg")))
            {
                touchSprite = Texture2D.FromStream(graphics.GraphicsDevice, textureFileStream);
            }
            spriteOrigin = new Vector2((float)touchSprite.Width / 2.0f,
                (float)touchSprite.Height / 2.0f);

            tailBatch = new SpriteBatch(graphics.GraphicsDevice);
            using (Stream textureFileStream = File.OpenRead(Path.Combine(path, "green2.png")))
            {
                tailSprite = Texture2D.FromStream(graphics.GraphicsDevice, textureFileStream);
            }
                tailOrigin = new Vector2((float)touchSprite.Width / 2.0f,
                (float)touchSprite.Height / 2.0f);


            // Create a new SpriteBatch, which can be used to draw textures.
           //SpriteBatch spriteBatch = new SpriteBatch(GraphicsDevice);
           // myTexture = Content.Load<Texture2D>("mytexture");
        }
        
        /// <summary>
        /// Unload your graphics content.
        /// </summary>
        protected override void UnloadContent()
        {
            Content.Unload();
        }
        
        /// <summary>                                                                          UPDATE
        /// Allows the app to run logic such as updating the world,
        /// checking for collisions, gathering input and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (ApplicationServices.WindowAvailability != WindowAvailability.Unavailable)
            {
                // get the current state
                ReadOnlyTouchPointCollection touches = touchTarget.GetState();

        //might benefit from a for each list in here!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!  ?
                //// next update the sprites list with new additions
                //InsertSpritesAtTouchPositions(touches);

                //Actually, first update the position of the E.coli
                MoveEcoli(gameTime);

                // Add an ecoli if the user touches surface
                InsertEcoliAtTouchPosition(touches);

                //First add a trail to where the ecoli has moved Do I need variable? 
                InsertTrailAfterEcoli();
                //spriteOrigin = orginPlaceHolder;
                
                
                // first update the state of any existing sprites
                ShrinkSprites((float)gameTime.ElapsedGameTime.Milliseconds /
                    (float)millisecondsToDisappear);

                // finally remove any invisible sprites
                RemoveInvisibleSprites();

                
            }

            base.Update(gameTime);
        }

        
        /// <summary>
        /// This is called when the app should draw itself.                                                    DRAW
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void 
            Draw(GameTime gameTime)
        {
            if (!applicationLoadCompleteSignalled)
            {
                // Dismiss the loading screen now that we are starting to draw
                ApplicationServices.SignalApplicationLoadComplete();
                applicationLoadCompleteSignalled = true;
            }

            graphics.GraphicsDevice.Clear(Color.Beige);

            //foregroundBatch.Begin();
            //tailBatch.Begin();

            //draw all of the ecoli in ecoliList
            int j = 0;
            foreach (LinkedList<SpriteData> ecoli in ecoliList)
            {
            //    //draw all the sprites in the ecolilist
            //    foreach (SpriteData sprite in ecoli)
            //    {
            //        foregroundBatch.Draw(touchSprite, sprite.Location, null, Color.White,
            //            sprite.Orientation, spriteOrigin, sprite.Scale, SpriteEffects.None, 0f);
            //    }
                    int i = 0;
                    j++;
                    
                    Console.WriteLine("I'm starting over a new ecolilist: " + j);
                    foreach (SpriteData sprite in ecoli)
                    {   
                        i++;
                        //LinkedListNode<SpriteData> currentNode = ecoli.First;
                        Console.WriteLine("sprite index" + i);


                            if (i == ecoli.Count-1)//maybe i'm not using the equal thing right? yupp.

                            {
                                Console.WriteLine("In the last");
                                foregroundBatch.Begin();
                                foregroundBatch.Draw(touchSprite, sprite.location, null, Color.White,
                                sprite.orientation, spriteOrigin, sprite.scale, SpriteEffects.None, 0f);
                                foregroundBatch.End();
                            }
                            else
                            {
                                tailBatch.Begin();
                                tailBatch.Draw(tailSprite, sprite.location, null, Color.White,
                                sprite.orientation, tailOrigin, sprite.scale, SpriteEffects.None, 0f);
                                tailBatch.End();
                            }
                    }
                }// after I changed this, it made the program extremely slow. NO this is not the cause!!



            //    // draw all the sprites in the list
            //    foreach (SpriteData sprite in spriteTail)
            //    {
            //        tailBatch.Draw(tailSprite, sprite.Location, null, Color.White,
            //            sprite.Orientation, spriteSpeed, sprite.Scale, SpriteEffects.None, 0f);
            //    }
            //}
            //foregroundBatch.End();
            //tailBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// This is called when the user can interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowInteractive(object sender, EventArgs e)
        {
            //TODO: enable audio, animations here
        }

        /// <summary>
        /// This is called when the user can see but not interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowNoninteractive(object sender, EventArgs e)
        {
            //TODO: Disable audio here if it is enabled

            //TODO: optionally enable animations here
        }

        /// <summary>
        /// This is called when the application's window is not visible or interactive.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowUnavailable(object sender, EventArgs e)
        {
            //TODO: disable audio, animations here
        }

        #endregion 

        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Release managed resources.              
                touchSprite.Dispose();
                foregroundBatch.Dispose();
                touchTarget.Dispose();

                IDisposable graphicsDispose = graphics as IDisposable;
                if (graphicsDispose != null)
                {
                    graphicsDispose.Dispose();
                }
            }

            // Release unmanaged Resources.

            base.Dispose(disposing);
        }

        #endregion       
    }

}
