using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Snake
{
	class Program
	{
		static void Main( string[] args )
		{
			Console.Title = "Змий";

			Console.Write("Выберите уровень (3, 2, 1): ");
			int difficulty = Int32.Parse(Console.ReadLine());

			Console.SetCursorPosition(0, 0);
			int score = 0;
			Console.Write("Счёт: " + score + "   Уровень сложности: " + difficulty);

			Console.SetBufferSize( 80, 25 );

			Walls walls = new Walls( 80, 25 );
			walls.Draw();

			// Отрисовка точек			
			Point p = new Point( 4, 5, 'o' );
			Snake snake = new Snake( p, 4, Direction.RIGHT );
			snake.Draw();

			FoodCreator foodCreator = new FoodCreator( 80, 25, 'W' );
			Point food = foodCreator.CreateFood();
			food.Draw();

			while (true)
			{
				if ( walls.IsHit(snake) || snake.IsHitTail() )
				{
					break;
				}
				if(snake.Eat( food ) )
				{
					food = foodCreator.CreateFood();
					food.Draw();
					Console.SetCursorPosition(0, 0);
					score++;
					Console.Write("Счёт: " + score + "   Уровень сложности: " + difficulty);
				}
				else
				{
					snake.Move();
				}

				Thread.Sleep( difficulty * 50);
				if ( Console.KeyAvailable )
				{
					ConsoleKeyInfo key = Console.ReadKey();
					snake.HandleKey( key.Key );
				}
			}
			WriteGameOver(score);
			Console.ReadLine();
      }


		static void WriteGameOver(int score)
		{
			Sound sound = new Sound();
			//sound.refrenSolo();
			//sound.coupleSolo();
			sound.funeralMarch();
			int xOffset = 24;
			int yOffset = 5;
			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.SetCursorPosition( xOffset, yOffset++ );
			WriteText( "============================", xOffset, yOffset++ );
			Console.ForegroundColor = ConsoleColor.Red;
			WriteText( "И Г Р А    О К О Н Ч Е Н А", xOffset + 1, yOffset++ );
			yOffset++;
			WriteText($"С О  С Ч Ё Т О М :   {score}", xOffset + 1, yOffset++);
			yOffset++;
			Console.ForegroundColor = ConsoleColor.DarkGreen;
			WriteText( "Автор: Евгений Картавец", xOffset + 2, yOffset++ );
			yOffset++;
			WriteText("Смотрельщик 'чёвнутри'", xOffset + 3, yOffset++);
			WriteText("и поправляльщик 'ятаквижу':", xOffset - 0, yOffset++);
			WriteText("Григорий Белоногов", xOffset + 4, yOffset++);
			yOffset++;
			WriteText( "Специально для GeekBrains", xOffset + 1, yOffset++ );
			WriteText( "============================", xOffset, yOffset++ );
		}

		static void WriteText( String text, int xOffset, int yOffset )
		{
			Console.SetCursorPosition( xOffset, yOffset );
			Console.WriteLine( text );
		}

	}
}
