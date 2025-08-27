using System;
using System.Numerics;

namespace Aligner.Models;

public class UserModel
{
    public string User_Id { get; set; } = "";
    public string Username { get; private set; } = "";
    public string First_Name { get; set; } = "";
    public BigInteger Phone_Number { get; set; } = 0;
}
