using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall;
using FlatRedBall.Input;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.Math.Geometry;
using System.Threading.Tasks;

namespace TriangleTest.Entities
{
	public partial class Cat
	{

        public I2DInput MovementInput { get; set; }
        public IPressableInput MeowInput { get; set; }

        /// <summary>
        /// Initialization logic which is execute only one time for this Entity (unless the Entity is pooled).
        /// This method is called when the Entity is added to managers. Entities which are instantiated but not
        /// added to managers will not have this method called.
        /// </summary>
		private void CustomInitialize()
		{


		}

		private void CustomActivity()
		{
            MovementActivity();
            MeowActivityAsync();
		}

		private void CustomDestroy()
		{


		}

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }

        private void MovementActivity()
        {
            if (MovementInput != null)
            {
                this.XVelocity = MovementInput.X * MovementSpeed;
                this.YVelocity = MovementInput.Y * MovementSpeed;
            }
        }

        private async Task MeowActivityAsync()
        {
            SoundEffect[] meows = new SoundEffect[14];
            meows[0] = sfinosMeow01;
            meows[1] = sfinosMeow02;
            meows[2] = sfinosMeow03;
            meows[3] = sfinosMeow04;
            meows[4] = sfinosMeow05;
            meows[5] = sfinosMeow06;
            meows[6] = sfinosMeow07;
            meows[7] = sfinosMeow08;
            meows[8] = sfinosMeow09;
            meows[9] = sfinosMeow10;
            meows[10] = sfinosMeow11;
            meows[11] = sfinosMeow12;
            meows[12] = sfinosMeow13;
            meows[13] = sfinosMeow14;

            Random random = new Random();
            int index = random.Next(0, 13);

            SoundEffect meow = meows[index];
            //meow = sfinosMeow01;

            System.TimeSpan meowTime = meow.Duration;
            if (MeowInput.WasJustPressed)
            {
                DateTime tThen = DateTime.Now;
                this.CurrentState = VariableState.MouthOpen;
                meow.Play();
                await Task.Delay(meowTime);
                this.CurrentState = VariableState.MouthClosed;
            }
        }
	}
}
