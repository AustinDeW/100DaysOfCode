#pragma once
#include <ctime>
#include <cstdlib>
#include <iostream>
#include <SFML\Graphics.hpp>

class Apple
{
public:
	Apple();
	~Apple();

	sf::Drawable& GetDrawable_Apple();
	sf::Vector2f GetPosition();
	void SetRadius(const float& radius);
	void Spawn(const sf::Vector2u& windowSize);	

private:
	const float APPLE_BOUNDS = 20;
	sf::CircleShape apple;
};

