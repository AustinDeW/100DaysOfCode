#include "GameWindow.h"

GameWindow::GameWindow(sf::VideoMode& vm, const std::string& title)
	:gameWindow(vm, title)
{
	while (gameWindow.GetWindow()->isOpen())
	{
		HandleInput();
		Update();
		gameWindow.BeginDraw();

		for (int i = 0; i < snake.body.size(); i++)
		{
			gameWindow.Draw(snake.body[i]);
		}

		gameWindow.Draw(apple.apple);

		gameWindow.EndDraw();
	}
}

GameWindow::~GameWindow()
{
}

void GameWindow::HandleInput()
{
	sf::Event event;
	while (gameWindow.GetWindow()->pollEvent(event))
	{
		if (event.type == sf::Event::Closed || event.key.code == sf::Keyboard::Escape)
		{
			gameWindow.CloseWindow();
		}
		else if (event.type == sf::Event::KeyPressed)
		{
			switch (event.key.code)
			{
				case sf::Keyboard::Up:
					key_up = true; key_down = false; key_right = false; key_left = false;
					break;
				case sf::Keyboard::Down:
					key_up = false; key_down = true; key_right = false; key_left = false;
					break;
				case sf::Keyboard::Right:
					key_up = false; key_down = false; key_right = true; key_left = false;
					break;
				case sf::Keyboard::Left:
					key_up = false; key_down = false; key_right = false; key_left = true;
					break;
			}
		}
		//else if (event.type == sf::Event::KeyReleased)
		//{
		//	switch (event.key.code)
		//	{
		//		case sf::Keyboard::Up:
		//			key_up = false;
		//			break;
		//		case sf::Keyboard::Down:
		//			key_down = false;
		//			break;
		//		case sf::Keyboard::Right:
		//			key_right = false;
		//			break;
		//		case sf::Keyboard::Left:
		//			key_left = false;
		//			break;
		//	}
		//}
	}
}

void GameWindow::Update()
{
	//std::cout << snake.GetStringDirection() << std::endl;
	snake.Move(key_up, key_down, key_right, key_left);
	if (snake.body[0].getGlobalBounds().intersects(apple.apple.getGlobalBounds()))
	{
		snake.Extend();
		apple.Spawn();
	}
}
