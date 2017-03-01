#include "Window.h"

Window::Window()
	:window(sf::VideoMode(600,800), "Snake")
{
}

Window::Window(sf::VideoMode& vm, const std::string& title)
	:window(vm,title)
{
}

Window::~Window()
{
}

sf::RenderWindow* Window::GetWindow()
{
	return &window;
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
