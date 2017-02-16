#pragma once
#include "Paddle.h"
class Game
{
	public:
	Game(sf::VideoMode vm, std::string title, int players);
	~Game();

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

};

