#include "Apple.h"

Apple::Apple()
{
	srand(std::time(NULL));
	apple.setPointCount(20);
	apple.setFillColor(sf::Color::Red);
}

Apple::~Apple()
{
}

sf::Drawable& Apple::GetDrawable_Apple()
{
	return apple;
}

sf::Vector2f Apple::GetPosition()
{
	return apple.getPosition();
}

void Apple::SetRadius(const float& radius)
{
	apple.setRadius(radius);
}

void Apple::Spawn(const sf::Vector2u& windowSize)
{
	float x = fmod(rand(), windowSize.x);
	float y = fmod(rand(), windowSize.y);

	apple.setPosition(x, y);

	// Makes sure that the whole apple spawns within the bounds of the world 
	if (x > windowSize.x - APPLE_PADDING)
		apple.setPosition(windowSize.x - APPLE_PADDING, y);
	else if (x < APPLE_PADDING)
		apple.setPosition(APPLE_PADDING, y);
	else if (y > windowSize.y - APPLE_PADDING)
		apple.setPosition(x, windowSize.y - APPLE_PADDING);
	else if (y < APPLE_PADDING)
		apple.setPosition(x, APPLE_PADDING);
}
