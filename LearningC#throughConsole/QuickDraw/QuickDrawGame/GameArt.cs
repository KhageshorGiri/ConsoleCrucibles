using System;

namespace QuickDrawGame;

public class GameArt
{

	public static string gameNameArt = @"
        ________        .__        __     ________                       
        \_____  \  __ __|__| ____ |  | __ \______ \____________ __  _  __
         /  / \  \|  |  \  |/ ___\|  |/ /  |    |  \_  __ \__  \\ \/ \/ /
        /   \_/.  \  |  /  \  \___|    <   |    `   \  | \// __ \\     / 
        \_____\ \_/____/|__|\___  >__|_ \ /_______  /__|  (____  /\/\_/  
               \__>             \/     \/         \/           \/        
                                                                         
                                                                         
                                                                         
                                                                         
                                                                         
	";

    public static string menu = """

	  Quick Draw

	  Face your opponent and wait for the signal. Once the
	  signal is given, shoot your opponent by pressing [space]
	  before they shoot you. It's all about your reaction time.

	  Choose Your Opponent:
	  [1] Easy....1000 milliseconds
	  [2] Medium...500 milliseconds
	  [3] Hard.....250 milliseconds
	  [4] Harder...125 milliseconds
	  [escape] give up
	""";

    public static string wait = """

	  Quick Draw
	                                                        
	                                                        
	                                                        
	              _O                          O_            
	             |/|_          wait          _|\|           
	             /\                            /\           
	            /  |                          |  \          
	  ------------------------------------------------------
	""";

    public static string fire = """

	  Quick Draw
	                                                        
	                         ********                       
	                         * FIRE *                       
	              _O         ********         O_            
	             |/|_                        _|\|           
	             /\          spacebar          /\           
	            /  |                          |  \          
	  ------------------------------------------------------
	""";

    public static string loseTooSlow = """

	  Quick Draw
	                                                        
	                                                        
	                                                        
	                                        > ╗__O          
	           //            Too Slow           / \         
	          O/__/\         You Lose          /\           
	               \                          |  \          
	  ------------------------------------------------------
	""";

    public static string loseTooFast = """

	  Quick Draw
	                                                        
	                                                        
	                                                        
	                         Too Fast       > ╗__O          
	           //           You Missed          / \         
	          O/__/\         You Lose          /\           
	               \                          |  \          
	  ------------------------------------------------------
	""";

    public static string win = """

	  Quick Draw
	                                                        
	                                                        
	                                                        
	            O__╔ <                                      
	           / \                               \\         
	             /\          You Win          /\__\O        
	            /  |                          /             
	  ------------------------------------------------------
	""";
}
