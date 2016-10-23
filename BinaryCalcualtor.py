def ConvertDecimalToBinary(result):
    x = result
    k = []
    negativenumber=False
    if str(result).startswith("-"):
        result=pow(2,8)+x
        negativenumber=True
    #print(x)
    while (result > 0):
        a = int(float(result % 2))
        k.append(a)
        result = (result - a) / 2
    k.append(0)
    binarystring = ""
    for j in k[::-1]:
        binarystring = binarystring + str(j)
    if negativenumber:
        binarystring1=binarystring[1:]
        return binarystring1
    else:
        return binarystring


def ConvertBinaryToDecimal(binary):
    negativenumber=False
    if(str(binary).startswith("1")):
        negativenumber=True
    decimal = 0
    for i in range(len(str(binary))):
        power = len(str(binary)) - (i + 1)
        decimal += int(str(binary)[i]) * (2 ** power)
    if(negativenumber):
        decimalnumber=decimal-pow(2,len(str(binary)))
        return decimalnumber
    else :
     return decimal


def VerfiytheResult(Result):
    if (Result >= -127 and Result <= 127):
        return True
    else:
        return False


loop = True
while loop:
    choice = input("Type 'Yes' to use binary calculator or Type 'No' to Exit\n")
    if choice.upper() == "YES":
        equation = input('Enter an input string\n')
    else:
        loop = False
        print("You have enterd NO")
        print("Thankyou for using binary calculator")
        break

    index = 0
    for c in equation:
        if c == "+" or c == "-" or c == "**" or c == "*" or c == "/":
            break
        index += 1
    num1 = equation[:index]
    num2 = equation[index + 1:]
    operator = equation[index]

    num1 = ConvertBinaryToDecimal(num1)
    #print(num1)
    num2 = ConvertBinaryToDecimal(num2)
    #print(num2)
    if operator == '+':
        value = num1 + num2
        #print(value)
        if (VerfiytheResult(value)):
            print(num1, "+", num2, "=", value)
            result = ConvertDecimalToBinary(value)
            print("final value after perfoming" + str(result))
        else:
            print("Result for the above operation will lead to overflow")
    elif operator == '-':
        value = num1 - num2
        #print(value)
        if (VerfiytheResult(value)):
            print(num1, "-", num2, "=", value)
            result = ConvertDecimalToBinary(value)
            print("final value after perfoming" + str(result))
        else:
            print("Result for the above operation will lead to overflow")

    elif operator == '*':
        value = num1 * num2
        #print(value)
        if (VerfiytheResult(value)):
            print(num1, "*", num2, "=", value)
            result = ConvertDecimalToBinary(value)
            print("final value after perfoming" + str(result))
        else:
            print("Result for the above operation will lead to overflow")

    elif operator == '/':
        if num2 != 0:
            value = num1 / num2
            #print(value)
            if (VerfiytheResult(value)):
                print(num1, "/", num2, "=", value)
                result = ConvertDecimalToBinary(value)
                print("final value after perfoming" + str(result))
            else:
                print("Result for the above operation will lead to overflow")
        else:
            print("Invalid operation")


    else:
        print("Invalid input")

