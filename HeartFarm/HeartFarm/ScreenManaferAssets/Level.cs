//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Content;
//using System.Xml;
//using HeartFarm.ScreenManagerAssets.Menus;
//using HeartFarm.Gameobjects;
//
//namespace HeartFarm
//{
//    class Level : Screen
//    {
//        BackgroundManager backgroundManager;
//        GameobjectManager gameobjectManager;
//
//        ContentManager _CM;
//
//        Tile referenceTile;
//        byte[,] _heightMap;
//        public float _aspectRatio;
//        Vector _playerPos;
//        public HeartFarm.Gameobjects.Hourglass.Gameover _gameover;
//        Rectangle _mapSize;
//
//        //hourglass spawning
//        int _hourglassSpawnTimer = 0;
//        int _hourglassSpawnDelay = 250;
//
//
//        Color _tint;
//
//        public Level(ContentManager CM, _removeScreen removeScreen, HeartFarm.Gameobjects.Hourglass.Gameover gameover, float aspectRatio, Color tint)
//            :base(removeScreen)
//        {
//            gameobjectManager = new GameobjectManager(CM, gameover);
//            
//            _aspectRatio = aspectRatio;
//            _CM = CM;
//            _tint = tint;
//            _gameover = gameover;
//
//            loadMap(CM, @"../../../Map1.tmx", aspectRatio);
//        }
//
//        public override Screen update(InputManager IM)
//        {
//            Screen nextScreen = null;
//            //here we will test for general keypresses (like for pause and such)
//            if (IM.CurrentGamePadState.Buttons.Start == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
//            {
//                //bring up the pause menu
//                nextScreen = new PauseMenu(CB_removeScreen, _CM, _tint, this);
//            }
//
//            //create a movement vector (y for up/down pixels, x for right/left pixels)
//            Vector movement = new Vector(IM.CurrentGamePadState.ThumbSticks.Left.X * 4, -IM.CurrentGamePadState.ThumbSticks.Left.Y * 4);
//
//            //make it ints
//            movement.X = (int)movement.X;
//            movement.Y = (int)movement.Y;
//
//            gameobjectManager.update(IM, movement);
//
//            if(movement.X != 0 || movement.Y != 0)
//            {
//                Vector referenceVec = new Vector((int)((-referenceTile.Position.X) + (400)), (-referenceTile.Position.X) + 400 / _aspectRatio);
//
//                movement = gameobjectManager.testCollision(_heightMap, _playerPos, movement);
//                _playerPos += movement;
//
//                Vector remainingMoves = backgroundManager.move(movement); //this will return the 
//                //remaining vector if it didn't move fully
//
//                if (remainingMoves.X != 0 || remainingMoves.Y != 0)
//                {
//                    gameobjectManager.move(remainingMoves);
//                }
//            }
//
//            gameobjectManager.moveObjects(new Vector(backgroundManager.ScreenBox.X, backgroundManager.ScreenBox.Y));
//
//
//            //spawn hourglasses
//            if (_hourglassSpawnTimer >= _hourglassSpawnDelay)
//            {
//                //find a position that we can put an hourglass
//                Random rgn = new Random(DateTime.Now.Millisecond);
//                Hourglass hourglass = new Hourglass(_CM, _gameover);
//
//                do
//                {
//                    hourglass.Position.X = (rgn.Next(1, _mapSize.Width)) * 32;
//                    hourglass.Position.Y = rgn.Next(1, _mapSize.Height) * 32;
//                } while (_heightMap[(int)hourglass.Position.X / 32, (int)hourglass.Position.Y / 32] == 1 || gameobjectManager.collidesWithList(hourglass));
//
//                //spawn an hourglass
//                gameobjectManager.addObject(hourglass);
//
//                _hourglassSpawnTimer = 0;
//                if(_hourglassSpawnDelay > 60)
//                    _hourglassSpawnDelay -= 10; // losses 1/6 of a second each time
//            }
//            else
//            {
//                _hourglassSpawnTimer++;
//            }
//
//            //update the rest
//            backgroundManager.update();
//
//            return nextScreen;
//        }
//
//        public override void draw(SpriteBatch spriteBatch, GameTime gametime)
//        {
//            backgroundManager.draw(spriteBatch, gametime);
//            gameobjectManager.draw(spriteBatch, gametime);
//        }
//
//        public void loadMap(ContentManager CM, string filename , float aspectRatio)
//        {
//            Rectangle mapArea = new Rectangle();
//            Tile[,] mapTiles = new Tile[1,1];
//            List<TileSet> tileSets = new List<TileSet>();
//
//            //spawn offset var
//            int spawnOffset = 0;
//
//            //load up the map
//            XmlTextReader xmlReader = new XmlTextReader(filename);
//
//            //tilesets first
//            while (xmlReader.Read())
//            {
//                if (xmlReader.Name == "map" && xmlReader.NodeType == XmlNodeType.Element)
//                {
//                    //get the width and height and create the array with them
//                    int width, height;
//                    xmlReader.MoveToAttribute("width");
//                    width = xmlReader.ReadContentAsInt();
//
//                    xmlReader.MoveToAttribute("height");
//                    height = xmlReader.ReadContentAsInt();
//
//                    mapArea = new Rectangle(0, 0, width, height);
//
//                    mapTiles = new Tile[mapArea.Width, mapArea.Height];
//                }
//                else if (xmlReader.Name == "tileset")
//                {
//                    if (!xmlReader.MoveToAttribute("name"))
//                    {
//                        continue;
//                    }
//                    string xmlString = xmlReader.ReadContentAsString();
//                    if (xmlString == "WallTiles" || xmlString == "FloorTiles")
//                        tileSets.Add(new TileSet(CM.Load<Texture2D>(xmlString)));
//                    else if (xmlString == "ObjectSpawns")
//                    {
//                        xmlReader.MoveToAttribute("firstgid");
//                        spawnOffset = xmlReader.ReadContentAsInt();
//                    }
//                }
//                else if (xmlReader.Name == "layer")
//                {
//                    xmlReader.MoveToAttribute("name");
//                    string xmlString = xmlReader.ReadContentAsString();
//                    
//                    if (xmlString == "Background")
//                    {
// #region Background_Code
//                        xmlReader.Read();
//                        //the REAL loading begins now
//                        xmlReader.MoveToContent();
//                        string map = xmlReader.ReadElementContentAsString();
//                        int[] mapInts = stringToIntArray(map, ',', mapArea.Height * mapArea.Width);
//
//                        for (int i = 0; i < mapArea.Width; i++)
//                        {
//                            for (int j = 0; j < mapArea.Height; j++)
//                            {
//                                //find the correct tile set
//                                for (int tileNumber = mapInts[i + j * mapArea.Width] - 1, tileSetNumber = 0; tileSetNumber < tileSets.Count;
//                                    tileNumber -= tileSets[tileSetNumber].numOfTiles, tileSetNumber++)
//                                {
//                                    if (tileNumber < tileSets[tileSetNumber].numOfTiles)
//                                    {
//                                        mapTiles[i, j] = new Tile(tileSets[tileSetNumber].texture, tileNumber, false);
//                                        break;
//                                    }
//                                }
//
//                            }
//                        }
//                        backgroundManager = new BackgroundManager(ref tileSets, ref mapTiles, ref mapArea, aspectRatio);
//                        referenceTile = mapTiles[0, 0];
//                        _mapSize = mapArea;
// #endregion
//                    }
//                    else if(xmlString == "HeightMap")
//                    {
//                        //load it into this class
// #region HeightMap_Code
//                    xmlReader.Read();
//                        xmlReader.MoveToContent();
//                        string heightMap = xmlReader.ReadElementContentAsString();
//                        _heightMap = new byte[mapArea.Width, mapArea.Height];
//                        if (heightMap == null)
//                        {
//                            continue; //a bad node got here
//                        }
//                        int[] mapInts = stringToIntArray(heightMap, ',', mapArea.Height * mapArea.Width);
//
//                        for (int i = 0; i < mapArea.Width; i++)
//                        {
//                            for (int j = 0; j < mapArea.Height; j++)
//                            {
//                                _heightMap[i, j] = (byte)(mapInts[i + j * mapArea.Width] - TileSet.totalTiles - 1);
//                            }
//
//                        }
//#endregion
//                    }
//                    else if (xmlString == "ObjectSpawns")
//                    {
//#region Spawns
//                    xmlReader.Read();
//                        //the REAL loading begins now
//                        xmlReader.MoveToContent();
//                        string map = xmlReader.ReadElementContentAsString();
//                        int[] mapInts = stringToIntArray(map, ',', mapArea.Height * mapArea.Width);
//
//                        List<Vector> hourglassPositions = new List<Vector>();
//
//                        for (int i = 0; i < mapInts.Length; i++)
//                        {
//                            mapInts[i] -= spawnOffset; //start them at 0
//                            if (mapInts[i] == 0)//must be the character spawn point
//                            {
//                                _playerPos = (new Vector(i % mapArea.Width, i / mapArea.Width) * 32);
//                                //backgroundManager.setSpawnPoint((new Vector(i % mapArea.Width, i / mapArea.Width) * 32));
//                                gameobjectManager.setSpawnPoint((new Vector(800, 800 / aspectRatio)));
//                            }
//                            else if(mapInts[i] == 1)
//                            {
//                                hourglassPositions.Add((new Vector(i % mapArea.Width, i / mapArea.Width) * 32));
//                            }
//                        }
//                        gameobjectManager.spawn(EnumGameObjects.Hourglass, hourglassPositions);
//#endregion
//                    }
//                }
//
//            } 
//                    
//
//
//            xmlReader.Close();
//
//            backgroundManager.setSpawnPoint(_playerPos);
//            backgroundManager.Tint = _tint;
//        }
//        private int[] stringToIntArray(string input, char delim, int size)
//        {
//            int[] retArray = new int[size];
//
//            for (int i = 0, n = 0; i < size; i++, n++)
//            {
//                int prevn = n;
//                while (n < input.Length && input[n] != delim)
//                {
//                    n++;
//                }
//
//                retArray[i] = Convert.ToInt32(input.Substring(prevn, n - prevn));
//
//            }
//            return retArray;
//        }
//
//        public override void onTop(bool toptop)
//        {
//            gameobjectManager.onTop(toptop);
//        }
//    }
//}
