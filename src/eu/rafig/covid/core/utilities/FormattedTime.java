package eu.rafig.covid.core.utilities;

import java.text.SimpleDateFormat;
import java.util.Date;

public class FormattedTime {
    private static Clocks clocks = new Clocks();

    public static String getGameLength() {
        return new SimpleDateFormat("mm:ss.mmm").format(new Date(clocks.getCurrentGameLength()));
    }

    public String finished() {
        return new SimpleDateFormat("HH:mm:ss.mmm").format(new Date(clocks.finished()));
    }
}
