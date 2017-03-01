#include "GameWindow.h"

GameWindow::GameWindow(sf::VideoMode& vm, const std::string& title)
	:gameWindow(vm, title)
{
	while (gameWindow.GetWindow()->isOpen())
	{
		HandleInput();
		Update();
		gameWindow.BeginDraw();
		//gameWindow.Draw();
		gameWindow.EndDraw();
	}
}

GameWindow::~GameWindow()
{
}

void GameWindow::HandleInput()
{
}

void GameWindow::Update()
{
}
