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

	for (int i = 1; i < 50; i++)
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

void Snake::Move(bool& up, bool& down, bool& right, bool& left)
{
	if (up || down || right || left)
	{
		for (int i = body.size() - 1; i > 0; --i)
		{
			body[i].setPosition(body[i - 1].getPosition().x + spacing_x, body[i - 1].getPosition().y + spacing_y);
		}
	}

	if (up)
	{
		snake_yPos = -VELOCITY;
		spacing_y = 13;
		spacing_x = 0;
	}
	else if (down)
	{
		snake_yPos = VELOCITY;
		spacing_y = -13;
		spacing_x = 0;
	}
	else if (up && down) snake_yPos = 0;
	else if (!up && !down) snake_yPos = 0;
	
	if (right)
	{
		snake_xPos = VELOCITY;
		spacing_x = -13;
		spacing_y = 0;
	}
	else if (left)
	{
		snake_xPos = -VELOCITY;
		spacing_x = 13;
		spacing_y = 0;
	}
	else if (right && left) snake_xPos = 0;
	else if (!right && !left) snake_xPos = 0;

	body[0].move(snake_xPos, snake_yPos);
}
