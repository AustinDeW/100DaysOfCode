#pragma once
#include "Window.h"
class GameWindow
{
	public:
	GameWindow(sf::VideoMode& vm, const std::string& title);
	~GameWindow();

	private:
	Window gameWindow;
	void HandleInput();
	void Update();
};

