#include "Game.h"

Game::Game(sf::VideoMode vm, std::string title)
	: window(vm, title), centerLine(sf::Vector2f(1, GetWindow()->getSize().x))
{
	window.setFramerateLimit(60);

	font.loadFromFile("Data/arial.ttf");

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
					MainMenu();
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

	if (player1.GetPosition()->y < 0) player1.SetPosition(sf::Vector2f(20, 0));
	if (player1.GetPosition()->y > 600 - player1.GetSize()->y) player1.SetPosition(sf::Vector2f(20, 500));
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

void Game::MainMenu()
{
	bool highlight_twoPlayer = false;
	bool highlight_singlePlayer = true;
	bool highlight_exit = false;
	mainMenuOpen = true;

	sf::Text title;
	title.setFont(font);
	title.setCharacterSize(72);
	title.setFillColor(sf::Color::Green);
	title.setString("PONG");
	sf::FloatRect titleRect = title.getLocalBounds();
	title.setOrigin(titleRect.left + titleRect.width / 2.0f, titleRect.top + titleRect.height / 2.0f);
	title.setPosition(sf::Vector2f(window.getSize().x / 2, 100));

	sf::Texture txtr_singlePlayer;
	txtr_singlePlayer.loadFromFile("Data/MainMenuSinglePlayerOption.png");
	sf::Texture txtr_twoPlayer;
	txtr_twoPlayer.loadFromFile("Data/MainMenuTwoPlayerOption.png");
	sf::Texture txtr_exit;
	txtr_exit.loadFromFile("Data/MainMenuExitOption.png");

	sf::RectangleShape menu_singlePlayer(sf::Vector2f(208,38));
	menu_singlePlayer.setTexture(&txtr_singlePlayer);
	menu_singlePlayer.setPosition(window.getSize().x / 2 - menu_singlePlayer.getSize().x / 2, 180);
	menu_singlePlayer.setOutlineColor(sf::Color::Green);

	sf::RectangleShape menu_twoPlayer(sf::Vector2f(178, 37));
	menu_twoPlayer.setTexture(&txtr_twoPlayer);
	menu_twoPlayer.setPosition(window.getSize().x / 2 - menu_twoPlayer.getSize().x / 2, 180 + 60);
	menu_twoPlayer.setOutlineColor(sf::Color::Green);

	sf::RectangleShape menu_exit(sf::Vector2f(62, 33));
	menu_exit.setTexture(&txtr_exit);
	menu_exit.setPosition(window.getSize().x / 2 - menu_exit.getSize().x / 2, 180 + 120);
	menu_exit.setOutlineColor(sf::Color::Green);

	while (mainMenuOpen)
	{
		sf::Event event;
		while (window.pollEvent(event))
		{
			if (event.type == sf::Event::Closed)
			{
				window.close();
				mainMenuOpen = false;
			}
			if (event.type == sf::Event::KeyPressed)
			{
				switch (event.key.code)
				{
					case sf::Keyboard::Escape:
						window.close();
						mainMenuOpen = false;
						break;
				}
			}
			if (event.type == sf::Event::KeyReleased)
			{

			}
			if (event.type == sf::Event::MouseButtonPressed)
			{
				if (menu_singlePlayer.getGlobalBounds().contains(event.mouseButton.x, event.mouseButton.y))
				{
					players = 1;
					window.clear(sf::Color::Black);
					window.display();
					mainMenuOpen = false;
				}
				else if (menu_twoPlayer.getGlobalBounds().contains(event.mouseButton.x, event.mouseButton.y))
				{
					players = 2;
					window.clear(sf::Color::Black);
					window.display();
					mainMenuOpen = false;
				}
				else if (menu_exit.getGlobalBounds().contains(event.mouseButton.x, event.mouseButton.y))
				{
					window.close();
					mainMenuOpen = false;
				}
			}
			if (event.type == sf::Event::MouseMoved)
			{
				if (menu_twoPlayer.getGlobalBounds().contains(event.mouseMove.x, event.mouseMove.y))
				{
					highlight_twoPlayer = true;	
					highlight_exit = false;
					highlight_singlePlayer = false;
				}
				else if (menu_singlePlayer.getGlobalBounds().contains(event.mouseMove.x, event.mouseMove.y))
				{
					highlight_twoPlayer = false;
					highlight_exit = false;
					highlight_singlePlayer = true;
				}
				else if (menu_exit.getGlobalBounds().contains(event.mouseMove.x, event.mouseMove.y))
				{
					highlight_twoPlayer = false;
					highlight_exit = true;
					highlight_singlePlayer = false;
				}				
			}
		}

		if (highlight_twoPlayer) menu_twoPlayer.setOutlineThickness(1);
		else menu_twoPlayer.setOutlineThickness(0);
		if (highlight_singlePlayer) menu_singlePlayer.setOutlineThickness(1);
		else menu_singlePlayer.setOutlineThickness(0);
		if (highlight_exit) menu_exit.setOutlineThickness(1);
		else menu_exit.setOutlineThickness(0);

		window.clear(sf::Color::Black);

		window.draw(title);
		window.draw(menu_singlePlayer);
		window.draw(menu_twoPlayer);
		window.draw(menu_exit);

		window.display();
	}
}
