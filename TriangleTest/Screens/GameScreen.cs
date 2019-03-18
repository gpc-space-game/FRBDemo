using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using FlatRedBall;
using FlatRedBall.Input;
using Microsoft.Xna.Framework.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.Math.Geometry;
using FlatRedBall.Localization;



namespace TriangleTest.Screens
{
	public partial class GameScreen
	{

		void CustomInitialize()
		{
            CatInstance.MovementInput =
                InputManager.Keyboard.Get2DInput(Keys.A,Keys.D,Keys.W,Keys.S);
            CatInstance.MeowInput = InputManager.Keyboard.GetKey(Keys.Space);
		}

		void CustomActivity(bool firstTimeCalled)
		{
            CollisionActivity();

		}

		void CustomDestroy()
		{


		}

        static void CustomLoadStaticContent(string contentManagerName)
        {


        }

        private void CollisionActivity()
        {
            foreach (var wall in Walls)
            {
                float playerMass = 0;
                float wallMass = 1;
                CatInstance.CollideAgainstMove(wall, playerMass, wallMass);
            }
        }

	}
}
