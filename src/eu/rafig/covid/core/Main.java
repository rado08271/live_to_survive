package eu.rafig.covid.core;

import eu.rafig.covid.core.ui.Console;
import eu.rafig.covid.core.ui.ConsoleStatus;
import eu.rafig.covid.core.utilities.Clocks;
import eu.rafig.covid.core.utilities.FormattedTime;

public class Main {
    public static void main(String[] args) {
        FormattedTime clocks = new FormattedTime();

        Console console = new Console();

        System.out.println(clocks.finished());
    }
}
