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
	void Move();

	private:
	Direction direction;
};

