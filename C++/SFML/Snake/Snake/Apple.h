#pragma once
#include <SFML\Graphics.hpp>
#include <cstdlib>
#include <ctime>
class Apple
{
	public:
	Apple();
	~Apple();

	sf::CircleShape apple;

	void Spawn();

	private:
	sf::Vector2f GenerateRandomPosition();
};

