﻿namespace Backend.Application.Dtos.AuthDtos
{
    public class LoginResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public string RefreshToken {  get; set; } = string.Empty;
    }
}
