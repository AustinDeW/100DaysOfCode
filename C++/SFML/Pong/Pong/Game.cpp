#include "Game.h"

Game::Game(sf::VideoMode vm, std::string title)
	: window(vm, title), centerLine(sf::Vector2f(1, GetWindow()->getSize().x))
{
	window.setFramerateLimit(60);

	centerLine.setFillColor(sf::Color::Green);
	centerLine.setPosition(401, 0);

	player1.SetPosition(sf::Vector2f(20, 300 - player1.GetSize()->y / 2));
	player2.SetPosition(sf::Vector2f(760, 300 - player2.GetSize()->y / 2));
}

sf::RenderWindow* Game::GetWindow()
{
	return &window;
}

void Game::HandleInput()
{
	sf::Event event;
	while (window.pollEvent(event))
	{
		if (event.type == sf::Event::Closed)
		{
			window.close();
		}

		if (event.type == sf::Event::KeyPressed)
		{
			switch (event.key.code)
			{
				case sf::Keyboard::Escape:
					window.close();
					break;
				case sf::Keyboard::Up:
					key_up = true;
					break;
				case sf::Keyboard::Down:
					key_down = true;
					break;
			}
		}

		if (event.type == sf::Event::KeyReleased)
		{
			switch (event.key.code)
			{
				case sf::Keyboard::Up:
					key_up = false;
					break;
				case sf::Keyboard::Down:
					key_down = false;
					break;
			}
		}
	}
}

void Game::Update()
{
	if (key_up) player1_yPos = -5;
	if (key_down) player1_yPos = 5;
	if (key_up && key_down) player1_yPos = 0;
	if (!key_up && !key_down) player1_yPos = 0;

	player1.Move(sf::Vector2f(0, player1_yPos));
}

void Game::Render()
{
	window.clear(sf::Color::Black);

	window.draw(centerLine);
	window.draw(*player1.GetDrawable());
	window.draw(*player2.GetDrawable());
	window.display();
}

Game::~Game()
{
}
