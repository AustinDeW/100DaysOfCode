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
					snake.SetDirection(Direction::UP);
					break;
				case sf::Keyboard::Down:
					snake.SetDirection(Direction::DOWN);
					break;
				case sf::Keyboard::Right:
					snake.SetDirection(Direction::RIGHT);
					break;
				case sf::Keyboard::Left:
					snake.SetDirection(Direction::LEFT);
					break;
			}
		}
		else if (event.type == sf::Event::KeyReleased)
		{
			switch (event.key.code)
			{
				case sf::Keyboard::Up:
					snake.SetDirection(Direction::NONE);
					break;
				case sf::Keyboard::Down:
					snake.SetDirection(Direction::NONE);
					break;
				case sf::Keyboard::Right:
					snake.SetDirection(Direction::NONE);
					break;
				case sf::Keyboard::Left:
					snake.SetDirection(Direction::NONE);
					break;
			}
		}
	}
}

void GameWindow::Update()
{
	//std::cout << snake.GetStringDirection() << std::endl;
	snake.Move();
}
