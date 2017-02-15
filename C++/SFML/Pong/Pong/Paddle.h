#pragma once
#include <SFML\Graphics.hpp>
class Paddle
{
	public:
	Paddle();
	~Paddle();

	const sf::Vector2f* GetPosition();
	void SetPosition(sf::Vector2f pos);
	const sf::Vector2f* GetSize();
	const sf::FloatRect* GetGlobalBounds();
	void Move(sf::Vector2f velocity);
	sf::RectangleShape* GetDrawable();

	private:
	sf::RectangleShape paddle;
};

