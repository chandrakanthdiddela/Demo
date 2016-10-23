/*
 * Copyright (C) 2014 maartenl
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
package Factorial_Test;

import java.math.BigDecimal;

/**
 * An example of tail recursion.
 *
 * @see https://wiki.openjdk.java.net/display/mlvm/TailCalls
 * @author mrbear
 */
public class TailRecursion
{

    /**
     * Computes the factorial of a number n.
     *
     * @param n
     * @return n!
     */
    public static BigDecimal factorial(BigDecimal n)
    {

        return factorial(BigDecimal.ONE, n);
    }

    /**
     * Computes the factorial of a number n with an accumulator.
     *
     * @param n
     * @return n!
     */
    private static BigDecimal factorial(BigDecimal accumulator, BigDecimal n)
    {
        if (BigDecimal.ZERO.equals(n))
        {
            return accumulator;
        }
        // currently tail recursion is not optimised in Java, therefore the StackOverflow
        // exception will occur here, the same as in the Recursion class.
        // see for more information: https://wiki.openjdk.java.net/display/mlvm/TailCalls
        // so the future syntax could become:
        // return goto factorial(accumulator.multiply(n), n.subtract(BigDecimal.ONE));
        return factorial(accumulator.multiply(n), n.subtract(BigDecimal.ONE));
    }

}
