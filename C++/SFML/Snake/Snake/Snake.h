#pragma once
#include <SFML/Graphics.hpp>
#include <iostream>
using SnakeContainer = std::vector<sf::RectangleShape>;
enum class Direction { NONE, UP, DOWN, RIGHT, LEFT };

class Snake
{
	public:
	Snake();
	~Snake();

	void Reset();

	void SetDirection(Direction dir);
	Direction GetDirection();
	std::string GetStringDirection();
	SnakeContainer body;
	void Move(bool& up, bool& down, bool& right, bool& left);

	private:
	Direction direction;
	float snake_yPos = 0, snake_xPos = 0;
	float spacing_y = 0, spacing_x = 0;
	const float VELOCITY = 4.0f;
};

