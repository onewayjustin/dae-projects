import Foundation
import CryptoKit

// ======================================================
// CYBERSECURITY OPERATIONS & DEFENSE SIMULATOR
// ======================================================

// MARK: - INCIDENT RESPONSE PLAN

func incidentResponsePlan() {
    print("""
    ===== INCIDENT RESPONSE PLAN =====

    Detection:
    Continuous monitoring and IDS identify threats.

    Containment:
    Infected systems isolated from network.

    Eradication:
    Malware removed and credentials reset.

    Recovery:
    Systems restored from backups.

    Example Attack:
    Ransomware encrypts files and demands payment.
    Response restores systems safely.
    """)
}

// MARK: - SECURITY POLICY & CIA TRIAD

func securityPolicy() {
    print("""
    ===== SECURITY POLICY =====

    Rules:
    - Strong passwords + MFA
    - Data encryption
    - Regular updates

    CIA TRIAD:
    Confidentiality → Encryption
    Integrity → Hash validation
    Availability → Backups & response plans
    """)
}

// MARK: - ENCRYPTION & HASHING DEMO

func encryptionDemo() {

    let text = "Cybersecurity is important"
    let key = SymmetricKey(size: .bits256)

    let encrypted = try! AES.GCM.seal(text.data(using: .utf8)!, using: key)
    let decrypted = try! AES.GCM.open(encrypted, using: key)

    let hash = SHA256.hash(data: text.data(using: .utf8)!)
    let hashString = hash.map { String(format:"%02hhx",$0) }.joined()

    print("""
    ===== ENCRYPTION & HASHING =====

    Original:
    \(text)

    Encrypted:
    \(encrypted.ciphertext.base64EncodedString())

    Decrypted:
    \(String(data: decrypted, encoding: .utf8)!)

    SHA256 Hash:
    \(hashString)
    """)
}

// MARK: - LEGAL & ETHICAL COMPLIANCE

func legalCompliance() {
    print("""
    ===== LEGAL & ETHICAL COMPLIANCE =====

    GDPR:
    Protects personal data.

    HIPAA:
    Protects healthcare information.

    Ethics:
    Responsible data handling
    Transparent breach disclosure
    """)
}

// ======================================================
// THREAT ANALYSIS
// ======================================================

func malwareAnalysis() {
    print("""
    ===== MALWARE ANALYSIS =====

    Platform: VirusTotal
    Malware: WannaCry Ransomware

    Detection Result:
    Detected by majority of AV vendors.

    Behavior:
    - Encrypts files
    - Modifies registry
    - Contacts command servers

    Impact:
    System downtime and data loss.
    """)
}

func phishingSimulation() {
    print("""
    ===== PHISHING SIMULATION =====

    Tool: Social Engineering Toolkit

    Attack:
    Fake login credential harvester.

    Risk:
    Users unknowingly submit passwords.

    Prevention:
    Security awareness training.
    """)
}

func aptAnalysis() {
    print("""
    ===== APT CAMPAIGN =====

    Group: APT28 (Fancy Bear)

    MITRE ATT&CK Mapping:
    T1566 - Phishing
    T1059 - Command Execution
    T1027 - Obfuscation

    Impact:
    Espionage and data theft.
    """)
}

// ======================================================
// VULNERABILITY ASSESSMENT
// ======================================================

func vulnerabilityScan() {
    print("""
    ===== VULNERABILITY SCAN =====

    Tool: Nmap

    Open Ports:
    22 SSH
    80 HTTP
    443 HTTPS

    Risk:
    Outdated SSH service detected.
    Classification: Medium Risk
    """)
}

func assetDiscovery() {
    print("""
    ===== ASSET DISCOVERY =====

    Discovered Devices:
    - Router
    - Workstation
    - Mobile Device

    Critical Asset:
    Database Server

    Network mapping completed.
    """)
}

// ======================================================
// THREAT INTELLIGENCE
// ======================================================

func threatIntelligence() {
    print("""
    ===== INDICATORS OF COMPROMISE =====

    IoC 1:
    Malicious IP: 185.220.101.1

    IoC 2:
    File Hash:
    e99a18c428cb38d5f260853678922e03

    Detection:
    Firewall + hash monitoring.

    Meaning:
    Known ransomware activity.
    """)
}

func openCTIImplementation() {
    print("""
    ===== OPENCTI PLATFORM =====

    Deployment: Docker

    Connectors:
    - MITRE ATT&CK
    - VirusTotal

    Purpose:
    Centralized threat intelligence analysis.
    """)
}

// ======================================================
// RISK MANAGEMENT
// ======================================================

func riskManagement() {
    print("""
    ===== RISK MANAGEMENT =====

    Risk 1:
    Open SSH Port
    Mitigation:
    Enable key authentication.

    Risk 2:
    Outdated Web Server
    Mitigation:
    Apply patches immediately.
    """)
}

func riskMonitoringProcedure() {
    print("""
    ===== RISK MONITORING =====

    - Weekly vulnerability scans
    - Log monitoring
    - Alert review
    - Patch verification
    """)
}

// ======================================================
// SECURITY MONITORING
// ======================================================

func securityMonitoring() {
    print("""
    ===== SECURITY MONITORING =====

    Detection Rule:
    Multiple failed login attempts.

    Alert Priority:
    High

    Response:
    Account lock + investigation.
    """)
}

// ======================================================
// MAIN MENU SYSTEM
// ======================================================

func mainMenu() {

    print("""
    ================================
      CYBERSECURITY DEFENSE SYSTEM
    ================================

    1. Incident Response
    2. Security Policy
    3. Encryption Demo
    4. Legal Compliance
    5. Malware Analysis
    6. Phishing Simulation
    7. APT Analysis
    8. Vulnerability Scan
    9. Asset Discovery
    10. Threat Intelligence
    11. OpenCTI
    12. Risk Management
    13. Security Monitoring
    """)

    if let choice = readLine() {

        switch choice {
        case "1": incidentResponsePlan()
        case "2": securityPolicy()
        case "3": encryptionDemo()
        case "4": legalCompliance()
        case "5": malwareAnalysis()
        case "6": phishingSimulation()
        case "7": aptAnalysis()
        case "8": vulnerabilityScan()
        case "9": assetDiscovery()
        case "10": threatIntelligence()
        case "11": openCTIImplementation()
        case "12": riskManagement()
        case "13": securityMonitoring()
        default: print("Invalid option")
        }
    }
}

// ======================================================
// PROGRAM START
// ======================================================

mainMenu()
