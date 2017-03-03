#include "Window.h"

Window::Window()
	:window(sf::VideoMode(800,600), "Snake")
{
	window.setFramerateLimit(60);
}

Window::Window(sf::VideoMode& vm, const std::string& title)
	:window(vm,title)
{
	window.setFramerateLimit(60);
}

Window::~Window()
{
}

sf::RenderWindow* Window::GetWindow()
{
	return &window;
}

void Window::CloseWindow()
{
	window.close();
}

void Window::BeginDraw()
{
	window.clear(sf::Color::Black);
}

void Window::Draw(sf::Drawable& drawable)
{
	window.draw(drawable);
}

void Window::EndDraw()
{
	window.display();
}

sf::Vector2u* Window::GetSize()
{
	return &window.getSize();
}
