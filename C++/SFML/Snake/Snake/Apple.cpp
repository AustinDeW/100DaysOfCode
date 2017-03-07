#include "Apple.h"

Apple::Apple()
	:apple(8,20)
{
	srand(time(NULL));
	Spawn();
}

void Apple::Spawn()
{
	apple.setFillColor(sf::Color::Red);
	apple.setPosition(GenerateRandomPosition());
}

sf::Vector2f Apple::GenerateRandomPosition()
{
	return sf::Vector2f(rand() % 768 + 32, rand() % 568 + 32);
}

Apple::~Apple()
{
}
