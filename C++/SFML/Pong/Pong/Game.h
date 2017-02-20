#pragma once
#include "Paddle.h"
#include "Ball.h"
#include <iostream>
#include <sstream>
class Game
{
	public:
	bool mainMenuOpen = true;
	sf::Font font;

	Game(sf::VideoMode vm, std::string title);
	~Game();

	void MainMenu();
	void ResetBall();
	void BackToMainMenu();

	sf::RenderWindow* GetWindow();
	void HandleInput();
	void Update();
	void Render();

	private:

	sf::RenderWindow window;
	sf::RectangleShape centerLine;
	sf::Text score;
	Paddle player1;
	Paddle player2;
	Ball ball;

	bool player1_key_up = false;
	bool player1_key_down = false;
	bool player2_key_up = false;
	bool player2_key_down = false;
	int player1_yPos = 0;
	int player2_yPos = 0;
	int players = 0;
	int ball_yPos = -2;
	int ball_xPos = -2;
	int player1_score = 0;
	int player2_score = 0;
};

