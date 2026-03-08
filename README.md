# Clipboard-Monitor
A class to grab clipboard commands for WPF

## Configuration

### Listener Console

The Listener can be configured via command-line arguments:

```bash
# Default (port 8080, all interfaces)
./Listener.Console

# Custom port
./Listener.Console 9000

# Custom address and port (e.g., specific IP)
# Note: Address must be a valid IP or "*" for all interfaces
```

**Arguments:**
- `arg[0]` - Port (default: 8080)
- `arg[1]` - Address (default: "*" for all interfaces)

### Broadcaster (Messenger)

The broadcaster can target any remote listener by setting the `Address` and `Port` properties:

```csharp
var handler = new HttpClientMessengerHandler
{
    Address = "http://192.168.1.100",  // Remote listener IP/hostname
    Port = "8080",                      // Listener port
    Enabled = true
};
```

**Default Values:**
- Address: `localhost`
- Port: `8080`

## Examples

### Starting listener on non-default port

```bash
# Run listener on port 9090
./Listener.Console 9090
```

### Broadcasting to remote listener

```csharp
var messenger = new HttpClientMessengerHandler
{
    Address = "http://192.168.0.100", // Remote machine IP
    Port = "8080",
    Enabled = true
};

await messenger.SendMessage("test message");
```

### curl example to verify listener

```bash
# Test the listener is running
curl -X POST http://localhost:8080/ \
  -H "Content-Type: text/plain" \
  -d 'test message'

# Test remote listener
curl -X POST http://192.168.1.100:8080/ \
  -H "Content-Type: text/plain" \
  -d 'test message'
```
