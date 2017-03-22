#pragma once
#include <ctime>
#include <cstdlib>
#include <SFML\Graphics.hpp>
class Apple
{
public:
	Apple();
	~Apple();

	sf::CircleShape apple;
	sf::Drawable& GetDrawable_Apple();
	
	void Spawn();	
};

