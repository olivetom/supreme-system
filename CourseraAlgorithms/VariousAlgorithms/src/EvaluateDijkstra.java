import java.util.Stack;

/**
 * Created by moliveto on 8/23/17.
 */
public class EvaluateDijkstra
{
    public static void main(String[] args)
    {
        Stack<Double> vals  = new Stack<>();
        Stack<String> ops = new Stack<String>();

//        String expression = "(1 + ((2 + 3) * (4 * 5)))"; // 101.0
        String expression = "(50 % 2)"; // 101.0
        String[] expArray = expression.split("");

        for (String s : expArray)
        {
            switch (s)
            {
                case "(":
                case " ": break;

                case "+":
                case "-":
                case "*":
                case "/":
                case "%":
                {
                    ops.push(s);
                    break;
                }


                case ")":
                {
                    Double op1 = vals.pop();
                    Double op2 = vals.pop();
                    switch (ops.pop())
                    {
                        case "+":
                        {
                            vals.push(op1 + op2);
                            break;
                        }
                        case "-":
                        {
                            vals.push(op1 - op2);
                            break;
                        }
                        case "*":
                        {
                            vals.push(op1 * op2);
                            break;
                        }
                        case "/":
                        {
                            vals.push(op1 / op2);
                            break;
                        }
                        case "%":
                        {
                            vals.push(op1 % op2);
                            break;
                        }
                    }
                    break;
                }
                default: // case of numbers
                {
                    vals.push(Double.parseDouble(s));
                }
            }
        }
        System.out.println(vals.pop());

    }
}
