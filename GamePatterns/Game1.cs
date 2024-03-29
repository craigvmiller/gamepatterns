﻿using GamePatterns.Database;
using GamePatterns.Messages;
using GamePatterns.Objects;
using GamePatterns.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Ninject;
using PubSub.Extension;

namespace GamePatterns
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private StateManager _stateManager;
        private DatabaseContext _database;
        private IKernel _kernel;

        public Game1()
        {
            _database = new DatabaseContext();

            _graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferHeight = 600,
                PreferredBackBufferWidth = 800
            };

            Content.RootDirectory = "Content";

            _kernel = new StandardKernel();
            _kernel.Bind<ContentManager>().ToConstant(Content);
            _kernel.Bind<GraphicsDeviceManager>().ToConstant(_graphics);
            _kernel.Bind<ICollisionHandler>().To<CollisionHandler>();
            _kernel.Bind<IGameObjectFactory>().To<GameObjectFactory>();

            _stateManager = new StateManager(_kernel, Content);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            this.Publish(new StateChangedMessage(typeof(ExploringState)));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            _stateManager.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            _graphics.GraphicsDevice.Clear(Color.Black);
            _stateManager.Draw(_spriteBatch, _graphics.GraphicsDevice);
            base.Draw(gameTime);
        }
    }
}
