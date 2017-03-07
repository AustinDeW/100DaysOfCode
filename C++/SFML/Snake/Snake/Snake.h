#pragma once
#include "Apple.h"
#include <iostream>
#include <stdlib.h>
using SnakeContainer = std::vector<sf::RectangleShape>;
enum class Direction { NONE, UP, DOWN, RIGHT, LEFT };

class Snake
{
	public:
	bool isGameOver = false;

	Snake();
	~Snake();

	void Reset();

	void SetDirection(Direction dir);
	Direction GetDirection();
	std::string GetStringDirection();
	SnakeContainer body;
	void Move(bool& up, bool& down, bool& right, bool& left);
	void Extend();

	private:
	Direction direction;
	float snake_yPos = 0, snake_xPos = 0;
	float spacing_y = 0, spacing_x = 0;
	const float VELOCITY = 4.0f;
};

