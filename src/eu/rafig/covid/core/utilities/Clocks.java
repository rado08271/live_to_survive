package eu.rafig.covid.core.utilities;

public class Clocks {
    private long start;
    private long end;

    public Clocks(){
        start = System.currentTimeMillis();
    }

    public long getCurrentGameLength(){
        return System.currentTimeMillis() - start;
    }

    public long finished() {
        end = System.currentTimeMillis();
        return end - start;
    }

}
