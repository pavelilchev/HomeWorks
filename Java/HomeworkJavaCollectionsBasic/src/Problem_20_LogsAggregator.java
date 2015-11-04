import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class Problem_20_LogsAggregator {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());
        String line = scanner.nextLine();
        TreeMap<String, TreeMap<String, Integer>> data = new TreeMap<String, TreeMap<String, Integer>>();

        for (int i = 0; i < n; i++) {
            String[] lineArgs = line.split(" ");
            String IP = lineArgs[0];
            String name = lineArgs[1];
            int duration = Integer.parseInt(lineArgs[2]);

            if (!data.containsKey(name)) {
                data.put(name, new TreeMap<String, Integer>());
            }
            if (!data.get(name).containsKey(IP)) {
                data.get(name).put(IP, duration);
            } else {
                int currentDuration = data.get(name).get(IP);
                data.get(name).put(IP, duration + currentDuration);
            }
            line = scanner.nextLine();
        }

        for (Map.Entry<String, TreeMap<String, Integer>> person : data.entrySet()) {
            String outpu = String.format("%s: ", person.getKey());

            int sum = 0;
            for (Map.Entry<String, Integer> logs : person.getValue().entrySet()) {
                sum += logs.getValue();
            }
            outpu += String.format("%d [", sum);

            for (Map.Entry<String, Integer> logs : person.getValue().entrySet()) {
                outpu += String.format("%s, ", logs.getKey());

            }
            outpu = outpu.substring(0, outpu.length() - 2);
            outpu += "]";

            System.out.println(outpu);
        }
    }
}
