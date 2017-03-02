#include "Snake.h"

Snake::Snake()
{
	Reset();
}

Snake::~Snake()
{
}

void Snake::Reset()
{
	direction = Direction::NONE;
	float startX = 400, startY = 300;
	body.push_back(sf::RectangleShape(sf::Vector2f(16,16)));
	body[0].setFillColor(sf::Color::Yellow);
	body[0].setPosition(startX, startY);

	for (int i = 1; i < 5; i++)
	{
		body.push_back(sf::RectangleShape(sf::Vector2f(16, 16)));
		body[i].setFillColor(sf::Color::Green);
		body[i].setPosition(startX, startY += 18);

	}
}

void Snake::SetDirection(Direction dir)
{
	direction = dir;
}

Direction Snake::GetDirection()
{
	return direction;
}

std::string Snake::GetStringDirection()
{
	std::string s_direction = "";
	switch (direction)
	{
		case Direction::NONE:
			s_direction = "NONE";
			break;
		case Direction::UP:
			s_direction = "UP";
			break;
		case Direction::DOWN:
			s_direction = "DOWN";
			break;
		case Direction::RIGHT:
			s_direction = "RIGHT";
			break;
		case Direction::LEFT:
			s_direction = "LEFT";
			break;
	}

	return s_direction;
}

void Snake::Move()
{
	switch (direction)
	{
		case Direction::UP:
			break;
		case Direction::DOWN:
			break;
		case Direction::LEFT:
			break;
		case Direction::RIGHT:
			break;
		case Direction::NONE:
			break;
	}
}
