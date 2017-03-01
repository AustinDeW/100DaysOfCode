#pragma once
#include <SFML\Graphics.hpp>
class Window
{
	public:
	Window();
	Window(sf::VideoMode& vm, const std::string& title);
	~Window();

	sf::RenderWindow* GetWindow();
	void BeginDraw();
	void Draw(sf::Drawable& drawable);
	void EndDraw();

	sf::Vector2u* GetSize();

	private:
	sf::RenderWindow window;
};

