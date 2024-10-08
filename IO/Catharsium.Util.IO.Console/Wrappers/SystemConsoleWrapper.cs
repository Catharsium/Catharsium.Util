﻿using Catharsium.Util.IO.Console.Interfaces;
using System;
using System.IO;
using System.Runtime.Versioning;

namespace Catharsium.Util.IO.Console.Wrappers;

public class SystemConsoleWrapper : IConsoleWrapper
{
    #region Basic

    [SupportedOSPlatform("Windows")]
    public string Title {
        get => System.Console.Title;
        set => System.Console.Title = value;
    }


    [SupportedOSPlatform("Windows")]
    public bool CapsLock => System.Console.CapsLock;

    #endregion

    #region IO

    public TextReader In => System.Console.In;

    public TextWriter Out => System.Console.Out;

    #endregion

    #region Buffer

    [SupportedOSPlatform("Windows")]
    public int BufferWidth {
        get => System.Console.BufferWidth;
        set => System.Console.BufferWidth = value;
    }


    [SupportedOSPlatform("Windows")]
    public int BufferHeight {
        get => System.Console.BufferHeight;
        set => System.Console.BufferHeight = value;
    }


    [SupportedOSPlatform("Windows")]
    public void SetBufferSize(int width, int height) {
        System.Console.SetBufferSize(width, height);
    }


    [SupportedOSPlatform("Windows")]
    public void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop) {
        System.Console.MoveBufferArea(sourceLeft, sourceTop, sourceWidth, sourceHeight, targetLeft, targetTop);
    }


    [SupportedOSPlatform("Windows")]
    public void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop, char sourceChar,
        ConsoleColor sourceForeColor, ConsoleColor sourceBackColor) {
        System.Console.MoveBufferArea(sourceLeft, sourceTop, sourceWidth, sourceHeight, targetLeft, targetTop, sourceChar, sourceForeColor,
            sourceBackColor);
    }

    #endregion

    #region Cursor

    public int CursorLeft {
        get => System.Console.CursorLeft;
        set => System.Console.CursorLeft = value;
    }


    public int CursorTop {
        get => System.Console.CursorTop;
        set => System.Console.CursorTop = value;
    }


    [SupportedOSPlatform("Windows")]
    public int CursorSize {
        get => System.Console.CursorSize;
        set => System.Console.CursorSize = value;
    }


    [SupportedOSPlatform("Windows")]
    public bool CursorVisible {
        get => System.Console.CursorVisible;
        set => System.Console.CursorVisible = value;
    }


    public void SetCursorPosition(int left, int top) {
        System.Console.SetCursorPosition(left, top);
    }

    #endregion

    #region Color

    public ConsoleColor ForegroundColor {
        get => System.Console.ForegroundColor;
        set => System.Console.ForegroundColor = value;
    }


    public ConsoleColor BackgroundColor {
        get => System.Console.BackgroundColor;
        set => System.Console.BackgroundColor = value;
    }


    public void ResetColor() {
        System.Console.ResetColor();
    }

    #endregion

    #region Beep

    [SupportedOSPlatform("Windows")]
    public void Beep(int frequency, int duration) {
        System.Console.Beep(frequency, duration);
    }

    #endregion

    #region Read

    public int Read() {
        return System.Console.Read();
    }


    public ConsoleKeyInfo ReadKey() {
        return System.Console.ReadKey();
    }


    public string ReadLine() {
        return System.Console.ReadLine();
    }

    #endregion

    #region Write

    public void Write(string text) {
        System.Console.Write(text);
    }


    public void WriteLine(string text = null) {
        if(text == null) {
            System.Console.WriteLine();
        }
        else {
            System.Console.WriteLine(text);
        }
    }


    public void WriteLine(string text, ConsoleColor color) {
        System.Console.ForegroundColor = color;
        System.Console.Write(text);
        System.Console.ResetColor();
    }

    #endregion

    #region Dimensions

    [SupportedOSPlatform("Windows")]
    public int WindowWidth {
        get => System.Console.WindowWidth;
        set => System.Console.WindowWidth = value;
    }


    public int LargestWindowWidth => System.Console.LargestWindowWidth;


    [SupportedOSPlatform("Windows")]
    public int WindowHeight {
        get => System.Console.WindowHeight;
        set => System.Console.WindowHeight = value;
    }


    public int LargestWindowHeight => System.Console.LargestWindowHeight;


    [SupportedOSPlatform("Windows")]
    public int WindowLeft {
        get => System.Console.WindowLeft;
        set => System.Console.WindowLeft = value;
    }


    [SupportedOSPlatform("Windows")]
    public int WindowTop {
        get => System.Console.WindowTop;
        set => System.Console.WindowTop = value;
    }


    [SupportedOSPlatform("Windows")]
    public void SetWindowPosition(int left, int top) {
        System.Console.SetWindowPosition(left, top);
    }


    [SupportedOSPlatform("Windows")]
    public void SetWindowSize(int width, int height) {
        System.Console.SetWindowSize(width, height);
    }

    #endregion
}