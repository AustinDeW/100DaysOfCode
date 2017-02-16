#pragma once
#include "Paddle.h"
#include <iostream>
class Game
{
	public:
	bool mainMenuOpen = true;
	sf::Font font;

	Game(sf::VideoMode vm, std::string title);
	~Game();

	void MainMenu();

	sf::RenderWindow* GetWindow();
	void HandleInput();
	void Update();
	void Render();

	private:

	sf::RenderWindow window;
	sf::RectangleShape centerLine;
	Paddle player1;
	Paddle player2;

	bool key_up = false;
	bool key_down = false;
	int player1_yPos = 0;
	int players = 0;

};

