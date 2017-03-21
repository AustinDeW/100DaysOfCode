#include "Snake.h"

Snake::Snake()
{
	// It's for the best...
	Snake::Reset();
}

Snake::~Snake()
{
}

void Snake::Reset()
{
	direction = Direction::NONE;
	float startX = 400, startY = 300;
	body.clear();
	body.push_back(sf::RectangleShape(sf::Vector2f(16,16)));
	body[0].setFillColor(sf::Color::Yellow);
	body[0].setPosition(startX, startY);

	for (int i = 1; i < 5; i++)
	{
		body.push_back(sf::RectangleShape(sf::Vector2f(16, 16)));
		body[i].setFillColor(sf::Color::Green);
		body[i].setPosition(startX, startY += 18);
	}

	clock.restart();
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
	if (up)
	{
		snake_yPos = -VELOCITY;
		spacing_y = 14;
		spacing_x = 0;
	}
	else if (down)
	{
		snake_yPos = VELOCITY;
		spacing_y = -14;
		spacing_x = 0;
	}
	else if (up && down) snake_yPos = 0;
	else if (!up && !down) snake_yPos = 0;
	
	if (right)
	{
		snake_xPos = VELOCITY;
		spacing_x = -14;
		spacing_y = 0;
	}
	else if (left)
	{
		snake_xPos = -VELOCITY;
		spacing_x = 14;
		spacing_y = 0;
	}
	else if (right && left) snake_xPos = 0;
	else if (!right && !left) snake_xPos = 0;

	body[0].move(snake_xPos, snake_yPos);
	if (up || down || right || left)
	{
		//// Problem is the body is moving to its position faster than the movement speed is
		for (int i = body.size() - 1; i > 0; --i)
		{
			body[i].setPosition(body[i - 1].getPosition().x + spacing_x, body[i - 1].getPosition().y + spacing_y);
			//std::cout << elapsed.asSeconds() << std::endl;
			//std::cout << body[i].getPosition().x << " " << body[i].getPosition().y << " \t ";
		}
		//std::cout << std::endl;
	}

	// Checks if snake head hits any of the walls
	if (body[0].getPosition().x < 0 ||
		body[0].getPosition().x > 800 - 16 ||
		body[0].getPosition().y < 0 ||
		body[0].getPosition().y > 600 - 16)
	{
		isGameOver = true;
		up = false; down = false; right = false; left = false;
		Reset();
	}
	

	// Checks if snake head hits any of its body
	for (int i = 1; i < body.size(); i++)
	{
		//if (body[0].getGlobalBounds().intersects(body[i].getGlobalBounds()))
		//{
		//	std::cout << "Intersects" << std::endl;
		//}
		if (body[0].getPosition() == body[i].getPosition())
		{
			std::cout << "Intersect" << std::endl;
		}
	}
}

void Snake::Extend()
{
	body.push_back(sf::RectangleShape(sf::Vector2f(16, 16)));
	body.at(body.size() - 1).setFillColor(sf::Color::Green);
}
